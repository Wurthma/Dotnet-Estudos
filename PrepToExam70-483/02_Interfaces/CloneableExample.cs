using System;
using System.IO;

namespace _02_Interfaces
{
    public class Pessoa : ICloneable
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Pessoa(){}
        public Pessoa(Pessoa p)
        {
            this.Nome = p.Nome;
            this.Idade = p.Idade;
        }

         public object Clone()
        {
            return new Pessoa(this);
        }
    }
}
