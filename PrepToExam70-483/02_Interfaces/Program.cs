using System;

namespace _02_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa { Nome = "Wurthmann", Idade = 32 };
            Pessoa pessoa_clone = (Pessoa)pessoa.Clone();
            Console.WriteLine("Wurthmann");
            Console.WriteLine(pessoa.Nome + " " + pessoa.Idade);
            Console.WriteLine("Wurthmann Clone");
            Console.WriteLine(pessoa_clone.Nome + " " + pessoa_clone.Idade);
            Console.ReadLine();
        }
    }
}
