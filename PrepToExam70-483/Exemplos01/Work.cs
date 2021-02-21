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
    }
}