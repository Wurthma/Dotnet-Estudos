using System;
using System.Collections.Generic;

namespace _05_Yield
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in PotenciaYield(2, 8))
            {
                Console.Write("{0} ", i);
            }
            Console.ReadKey();
        }

        public static IEnumerable<int> PotenciaYield(int numero, int exponente)
        { // Esse método é equivalente ao método PotenciaSemYield
            int resultado = 1;
            for (int i = 0; i < exponente; i++)
            {
                resultado = resultado * numero;
                yield return resultado;
            }
        }
        
        
        public static IEnumerable<int> PotenciaSemYield(int numero, int exponente)
        { // Esse método é equivalente ao método PotenciaYield
            int resultado = 1;
            var list = new List<int>();
            for (int i = 0; i < exponente; i++)
            {
                resultado = resultado * numero;
                list.Add(resultado);
            }
            return list;
        }
    }
}
