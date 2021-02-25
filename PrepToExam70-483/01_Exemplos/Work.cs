using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Exemplos01
{
    public class Work
    {
        public Work(){}

        public void DoWork()
        {
            for(int i = 0; i < 10; i++){
                Thread.Sleep(100);
                Console.Write(i);
                Console.Write(", ");
            }
        }

        public int DoWork2()
        {
            int sum = 0;
            for(int i = 0; i < 15; i++){
                Thread.Sleep(70);
                Console.Write(i);
                Console.Write(", ");
                sum += i;
            }

            return sum;
        }

        public int DoWork3(int value)
        {
            int sum = 0;
            for(int i = 0; i < 12; i++){
                Thread.Sleep(55);
                Console.Write(i);
                Console.Write(", ");
                sum += i;
            }

            return sum + value;
        }

        public void DoWork4()
        {
            for(int i = 0; i < 10; i++){
                Thread.Sleep(120);
                Console.Write(i);
                Console.Write(", ");
            }
        }

        public bool DoLongWork()
        {
            int sum = 0;
            for(int i = 0; i < 10; i++){
                Thread.Sleep(2000);
                sum += i;
            }

            return true;
        }

        private List<Guid> GenerateResults()
        {
            List<Guid> listResults = new List<Guid>();
            for(int i = 0; i <= 100; i++)
            {
                listResults.Add(Guid.NewGuid());
            }
            return listResults;
        }
        
        public void ProcessResultsParallel()
        {
            var listResults = GenerateResults();

            // Caso queira controlar quantidade de Threads (entre outras opções) - Exemplo completo no readme.md
            // ParallelOptions op = new ParallelOptions();
            // op.MaxDegreeOfParallelism = 10;

            Parallel.ForEach(listResults, item => {
                ProcessResult(item);
            });

            Console.WriteLine();
        }

        public void ProcessResults()
        {
            var listResults = GenerateResults();
            foreach(var item in listResults)
                ProcessResult(item);

            Console.WriteLine();
        }

        private void ProcessResult(Guid result)
        {
            // Processar alguma coisa
            Thread.Sleep(50);
            Console.WriteLine($"{result.ToString()} - Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}