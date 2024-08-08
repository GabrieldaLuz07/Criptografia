using Criptografia;
using System;

class Program
{
        static void Main(string[] args)
        {
            GerenciarCriptografia gerenciador = new GerenciarCriptografia();

            Console.WriteLine("Escolha o método de criptografia (1: Simétrica, 2: Assimétrica): ");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha == 1)
            {
                gerenciador.DefinirCriptografia(new CriptografiaSimetrica());
            }
            else if (escolha == 2)
            {
                var criptografiaAssimetrica = new CriptografiaAssimetrica();
                gerenciador.DefinirCriptografia(criptografiaAssimetrica);

                // Exportar e importar chave pública (exemplo de uso)
                var chavePublica = criptografiaAssimetrica.ExportarChavePublica();
                criptografiaAssimetrica.ImportarChavePublica(chavePublica);
            }
            else
            {
                Console.WriteLine("Escolha inválida.");
                return;
            }

            // Criptografar texto
            Console.WriteLine("Digite o texto para criptografar: ");
            string textoParaCriptografar = Console.ReadLine();
            byte[] dadosCriptografados = gerenciador.CriptografarTexto(textoParaCriptografar);
            string textoCriptografado = Convert.ToBase64String(dadosCriptografados);
            Console.WriteLine($"Texto criptografado: {textoCriptografado}");

            // Descriptografar texto
            Console.WriteLine("Digite o texto criptografado para descriptografar (em base64): ");
            string textoCriptografadoEntrada = Console.ReadLine();
            byte[] dadosCriptografadosEntrada = Convert.FromBase64String(textoCriptografadoEntrada);
            string textoDescriptografado = gerenciador.DescriptografarTexto(dadosCriptografadosEntrada);
            Console.WriteLine($"Texto descriptografado: {textoDescriptografado}");

            // Criptografar arquivo
            Console.WriteLine("Digite o caminho do arquivo para criptografar: ");
            string caminhoArquivoEntrada = Console.ReadLine();
            byte[] arquivoCriptografado = gerenciador.CriptografarArquivo(caminhoArquivoEntrada);
            string caminhoArquivoCriptografado = "arquivoCriptografado.bin";
            File.WriteAllBytes(caminhoArquivoCriptografado, arquivoCriptografado);
            Console.WriteLine($"Arquivo criptografado salvo em: {caminhoArquivoCriptografado}");

            // Descriptografar arquivo
            Console.WriteLine("Digite o caminho do arquivo criptografado para descriptografar: ");
            string caminhoArquivoEntradaCriptografado = Console.ReadLine();
            string caminhoArquivoDescriptografado = "arquivoDescriptografado.txt";
            gerenciador.DescriptografarArquivo(caminhoArquivoEntradaCriptografado, caminhoArquivoDescriptografado);
            Console.WriteLine($"Arquivo descriptografado salvo em: {caminhoArquivoDescriptografado}");
        }
}