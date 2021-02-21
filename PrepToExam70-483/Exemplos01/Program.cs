using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplos01
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            await ShowMenuSamples();
        }
        
        private static async Task ShowMenuSamples()
        {
            Console.Clear();
            Console.WriteLine("1- Execução básica de processos com Thread, ThreadPool e Tasks");
            Console.WriteLine("2- Thread ContinueWith");
            Console.WriteLine("3- Executando uma lista de tasks");
            Console.WriteLine("4- Tasks async");

            string option = Console.ReadKey().KeyChar.ToString();
            switch(option)
            {
                case "1":
                    Option1();
                    break;
                case "2":
                    Option2();
                    break;
                case "3":
                    Option3();
                    break;
                case "4":
                    await Option4();
                    break;
                default:
                    return;
            }
        }

        private static void Option1()
        {
            // Execução sem paralelismo
            ExecuteWork();

            //Utilizando threads:
            ExecuteWorkWithThread();

            //Utilizando threadPool:
            ExecuteWorkWithThreadPool();
            
            // Utilizando tasks:
            ExecuteWorkWithTask_Type1(); 
            ExecuteWorkWithTask_Type2();
            ExecuteWorkWithTask_Type3();

            Console.ReadKey();
        }

        private static void Option2()
        {
            Work work = new Work();
            
            // Execução de exemplo onde uma ordem de passos deve ser seguida
            // Exemplos com 3 passos: passo1 (DoWork), passo2 (DoWork2) e passo3 (DoWork3)
            
            // 1
            Task passo1 = Task.Factory.StartNew(() =>{
                work.DoWork();
            });

            // 2
            int resultValue = 0;
            Task passo2 = passo1.ContinueWith((value) => {
                resultValue = work.DoWork2();
            });

            int resultadoFinal = 0;
            Task passo3 = passo1.ContinueWith((value) => {
                resultadoFinal = resultValue = work.DoWork3(resultValue);
            });

            while(true)
            { // Aguarda conclusão
                if(passo3.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Resultado final = {resultadoFinal}");
                    Console.ReadKey();
                    return;
                }
            }
        }

        private static void Option3()
        {
            Work work = new Work();
            Task[] tasks = new Task[3]
            {
                Task.Factory.StartNew(() => {
                    work.DoWork();
                }),
                Task.Factory.StartNew(() => {
                    work.DoWork2();
                }),
                Task.Factory.StartNew(() => {
                    work.DoWork3(5);
                })
            };

            Task.WaitAll(tasks);
            Console.WriteLine();
            Console.WriteLine("Finalizado!");
            Console.ReadKey();
        }

        private static async Task Option4()
        {
            Work work = new Work();
            Console.WriteLine();

            // Executando outras tarefas em paralelo...
            Task task1 = Task.Factory.StartNew(() =>{
                work.DoWork4();
            });
            Task task2 = Task.Factory.StartNew(() =>{
                work.DoWork4();
            });

            var task = await ExecuteWorkWithTaskAsync();
            
            if(task)
            {
                Console.WriteLine();
                Console.WriteLine("Concluído! Programa finalizado...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Tarefa em execução");
            }
        }
        private static void ExecuteWork()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Executando trabalho sem paralelismo");
            Work work = new Work();
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            // Funcionamento sem o uso de task:
            work.DoWork();
            var result = work.DoWork2();
            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Trabalhos finalizados em {stopwatch.Elapsed.TotalSeconds} segundos");
            Console.WriteLine($"Resultado do trabalho 2 = {result}");
        }

        private static void ExecuteWorkWithThread()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Executando trabalho com Thread");
            Work work = new Work();
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            Thread thread = new Thread(new ThreadStart(work.DoWork));
            thread.Start();
            int result = 0;
            Thread thread2 = new Thread(
                new ThreadStart(() => {
                    result = work.DoWork2();
                })
            );
            thread2.Start();

            while(true)
            {
                if(!thread.IsAlive && !thread2.IsAlive)
                {// para o stopwatch apenas quando as threads forem concluídas
                    stopwatch.Stop();
                    Console.WriteLine();
                    Console.WriteLine($"Trabalhos finalizados em {stopwatch.Elapsed.TotalSeconds} segundos");
                    Console.WriteLine($"Resultado do trabalho 2 = {result}");
                    return;
                }
            }
        }
        
        private static void ExecuteWorkWithThreadPool()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Executando trabalho com ThreadPool");
            Work work = new Work();
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            var events = new List<ManualResetEvent>();
            ManualResetEvent resetEvent = new ManualResetEvent(false); // usado para controlar o término da execução
            ThreadPool.QueueUserWorkItem(state => { 
                work.DoWork(); 
                resetEvent.Set();
            });
            events.Add(resetEvent);

            int result = 0;
            ManualResetEvent resetEvent2 = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(state => {
                result = work.DoWork2();
                resetEvent2.Set();
            });
            events.Add(resetEvent2);

            WaitHandle.WaitAll(events.ToArray()); // Espera por todos eventos do 'List<ManualResetEvent> events'

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Trabalhos finalizados em {stopwatch.Elapsed.TotalSeconds} segundos");
            Console.WriteLine($"Resultado do trabalho 2 = {result}");
        }

        private static void ExecuteWorkWithTask_Type1()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Executando trabalho com Tasks (tipo 1)");
            Work work = new Work();
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            // maneira 1 utilizando tasks
            Task task = new Task(work.DoWork);
            task.Start();
            Task<int> task2 = new Task<int>(work.DoWork2);
            task2.Start();
            
            while(true)
            {
                if(task.Status == TaskStatus.RanToCompletion && task2.Status == TaskStatus.RanToCompletion)
                {// para o stopwatch apenas quando as tarefas forem concluídas
                    stopwatch.Stop();
                    Console.WriteLine();
                    Console.WriteLine($"Trabalhos finalizados em {stopwatch.Elapsed.TotalSeconds} segundos");
                    Console.WriteLine($"Resultado do trabalho 2 = {task2.Result}");
                    return;
                }
            }
        }

        private static void ExecuteWorkWithTask_Type2()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Executando trabalho com Tasks (tipo 2)");
            Work work = new Work();
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            // maneira 1 utilizando tasks
            Task task = Task.Run(() => work.DoWork());
            Task<int> task2 = Task.Run(() => work.DoWork2());
            
            while(true)
            {
                if(task.Status == TaskStatus.RanToCompletion && task2.Status == TaskStatus.RanToCompletion)
                {// para o stopwatch apenas quando as tarefas forem concluídas
                    stopwatch.Stop();
                    Console.WriteLine();
                    Console.WriteLine($"Trabalhos finalizados em {stopwatch.Elapsed.TotalSeconds} segundos");
                    Console.WriteLine($"Resultado do trabalho 2 = {task2.Result}");
                    return;
                }
            }
        }

        private static void ExecuteWorkWithTask_Type3()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Executando trabalho com Tasks (tipo 3)");
            Work work = new Work();
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            // maneira 1 utilizando tasks
            Task task = Task.Factory.StartNew(work.DoWork);
            Task<int> task2 = Task.Factory.StartNew(work.DoWork2);
            
            while(true)
            {
                if(task.Status == TaskStatus.RanToCompletion && task2.Status == TaskStatus.RanToCompletion)
                {// para o stopwatch apenas quando as tarefas forem concluídas
                    stopwatch.Stop();
                    Console.WriteLine();
                    Console.WriteLine($"Trabalhos finalizados em {stopwatch.Elapsed.TotalSeconds} segundos");
                    Console.WriteLine($"Resultado do trabalho 2 = {task2.Result}");
                    return;
                }
            }
        }

        private static async Task<bool> ExecuteWorkWithTaskAsync()
        {
            Work work = new Work();
            return await Task.Run(() => {
                return work.DoLongWork();
            });
        }
    }
}
