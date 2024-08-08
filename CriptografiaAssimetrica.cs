using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Timer = System.Timers.Timer;
using System.IO;

namespace Criptografia
{
    public class CriptografiaAssimetrica : ICriptografar
    {

        private readonly RSA rsa;

        public CriptografiaAssimetrica()
        {
            rsa = RSA.Create();
        }

        public byte[] Criptografar(string textoPlano)
        {
            return rsa.Encrypt(Encoding.UTF8.GetBytes(textoPlano), RSAEncryptionPadding.OaepSHA256);
        }

        public string Descriptografar(byte[] textoCifrado)
        {
            return Encoding.UTF8.GetString(rsa.Decrypt(textoCifrado, RSAEncryptionPadding.OaepSHA256));
        }

        public byte[] CriptografarArquivo(string caminhoArquivo)
        {
            byte[] arquivoBytes = File.ReadAllBytes(caminhoArquivo);
            return Criptografar(Encoding.UTF8.GetString(arquivoBytes));
        }

        public void DescriptografarArquivo(string caminhoArquivoEntrada, string caminhoArquivoSaida)
        {
            byte[] arquivoCifrado = File.ReadAllBytes(caminhoArquivoEntrada);
            string textoDescriptografado = Descriptografar(arquivoCifrado);
            File.WriteAllBytes(caminhoArquivoSaida, Encoding.UTF8.GetBytes(textoDescriptografado));
        }

        public RSAParameters ExportarChavePublica()
        {
            return rsa.ExportParameters(false);
        }

        public void ImportarChavePublica(RSAParameters chavePublica)
        {
            rsa.ImportParameters(chavePublica);
        }
    }
}
