using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplos01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Execução sem paralelismo
            ExecuteWork();

            //Utilizando threads:
            ExecuteWorkWithThread();
            
            // Utilizando tasks:
            ExecuteWorkWithTask_Type1(); 
            ExecuteWorkWithTask_Type2();
            ExecuteWorkWithTask_Type3();

            Console.ReadKey();
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
    }
}
