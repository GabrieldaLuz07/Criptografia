using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia
{
    public class GerenciarCriptografia
    {
        private ICriptografar criptografia;

        public void DefinirCriptografia(ICriptografar criptografia)
        {
            this.criptografia = criptografia;
        }

        public byte[] CriptografarTexto(string textoPlano)
        {
            return criptografia.Criptografar(textoPlano);
        }

        public string DescriptografarTexto(byte[] textoCifrado)
        {
            return criptografia.Descriptografar(textoCifrado);
        }

        public byte[] CriptografarArquivo(string caminhoArquivo)
        {
            return criptografia.CriptografarArquivo(caminhoArquivo);
        }

        public void DescriptografarArquivo(string caminhoArquivoEntrada, string caminhoArquivoSaida)
        {
            criptografia.DescriptografarArquivo(caminhoArquivoEntrada, caminhoArquivoSaida);
        }
    }
}
