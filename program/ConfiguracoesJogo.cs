using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    using System.IO;

    class ConfiguracoesJogo
    {
        private const string ConfiguracoesArquivo = "C:\\Users\\danilo\\OneDrive\\Programação\\Faculdade\\ATP\\campo-minado\\program\\configuracoes.txt";

        public static Configuracoes LerConfiguracoes()
        {
            if (File.Exists(ConfiguracoesArquivo))
            {
                string[] linhas = File.ReadAllLines(ConfiguracoesArquivo);
                if (linhas.Length >= 3 &&
                    int.TryParse(linhas[0], out int linhasTabuleiro) &&
                    int.TryParse(linhas[1], out int colunasTabuleiro) &&
                    int.TryParse(linhas[2], out int quantidadeMinas))
                {
                    return new Configuracoes(linhasTabuleiro, colunasTabuleiro, quantidadeMinas);
                }
            }
            return null;
        }

        public static void SalvarConfiguracoes(Configuracoes configuracoes)
        {
            string[] linhas = {
            configuracoes.LinhasTabuleiro.ToString(),
            configuracoes.ColunasTabuleiro.ToString(),
            configuracoes.QuantidadeMinas.ToString()
        };
            File.WriteAllLines(ConfiguracoesArquivo, linhas);
        }

        public static void MudarConfiguracoes()
        {
            Console.WriteLine("Digite o número de linhas do tabuleiro:");
            int linhasTabuleiro = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número de colunas do tabuleiro:");
            int colunasTabuleiro = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número de minas:");
            int quantidadeMinas = int.Parse(Console.ReadLine());

            // Atualizar o arquivo de configurações
            Configuracoes configuracoes = new Configuracoes(linhasTabuleiro, colunasTabuleiro, quantidadeMinas);
            ConfiguracoesJogo.SalvarConfiguracoes(configuracoes);

            Console.WriteLine("Configurações alteradas com sucesso!");
        }
    }

}
