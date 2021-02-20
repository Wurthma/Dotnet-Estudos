using System;
using System.Threading;

namespace Exemplos01
{
    public class Work
    {
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
    }
}