using System;
using System.IO;

namespace _02_Interfaces
{
    public class GerenciaArquivos : IDisposable
    {
        FileStream fileStream;
        public GerenciaArquivos(string caminhoArquivo)
        {
            fileStream = new FileStream(caminhoArquivo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
        
        public void Write(byte[] dados)
        {
            fileStream.Write(dados, 0, dados.Length);
        }

        public void Dispose()
        {
            fileStream.Close();
        }
    }
}
