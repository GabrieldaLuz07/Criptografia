using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia
{
    public class CriptografiaSimetrica : ICriptografar
    {
        private readonly byte[] chave;
        private readonly byte[] iv;

        public CriptografiaSimetrica()
        {
            using (Aes aes = Aes.Create())
            {
                chave = aes.Key;
                iv = aes.IV;
            }
        }

        public byte[] Criptografar(string textoPlano)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = chave;
                aes.IV = iv;
                ICryptoTransform criptografador = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, criptografador, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(textoPlano);
                        }
                        return ms.ToArray();
                    }
                }
            }
        }

        public string Descriptografar(byte[] textoCifrado)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = chave;
                aes.IV = iv;
                ICryptoTransform descriptografador = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(textoCifrado))
                {
                    using (CryptoStream cs = new CryptoStream(ms, descriptografador, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
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
    }
}
