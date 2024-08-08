using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Criptografia
{
    public interface ICriptografar
    {
        byte[] Criptografar(string textoPlano);
        string Descriptografar(byte[] textoCifrado);
        byte[] CriptografarArquivo(string caminhoArquivo);
        void DescriptografarArquivo(string caminhoArquivoEntrada, string caminhoArquivoSaida);

    }
}
