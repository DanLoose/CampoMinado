using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace program
{
    class MenuJogo
    {
        public enum OpcoesInicioPrograma { Jogar = 1, MostrarConfiguracoes, MudarConfiguracoes, Sair };
        public static void ExibirMenu()
        {
            OpcoesInicioPrograma opcaoEscolhida;

            do
            {

                Configuracoes configuracoes = ConfiguracoesJogo.LerConfiguracoes();

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine($"{((int)OpcoesInicioPrograma.Jogar)}. Jogar");
                Console.WriteLine($"{((int)OpcoesInicioPrograma.MostrarConfiguracoes)}. Mostrar Configurações");
                Console.WriteLine($"{((int)OpcoesInicioPrograma.MudarConfiguracoes)}. Mudar Configurações");
                Console.WriteLine($"{((int)OpcoesInicioPrograma.Sair)}. Sair");

                if (Enum.TryParse(Console.ReadLine(), out opcaoEscolhida))
                {
                    switch (opcaoEscolhida)
                    {
                        case OpcoesInicioPrograma.Jogar:
                            Console.WriteLine("Opção escolhida: Jogar");

                            if (configuracoes == null)
                            {
                                Console.WriteLine("As configurações do jogo não foram encontradas.");
                                Console.WriteLine("Por favor, configure o jogo antes de jogar.");
                                break;
                            }

                            Jogo jogo = new Jogo(configuracoes);
                            jogo.Jogar();

                            break;
                        case OpcoesInicioPrograma.MostrarConfiguracoes:
                            Console.WriteLine("Opção escolhida: Mostrar Configurações");

                            if (configuracoes != null)
                            {
                                Console.WriteLine("Configurações do Jogo:");
                                Console.WriteLine($"Linhas do Tabuleiro: {configuracoes.LinhasTabuleiro}");
                                Console.WriteLine($"Colunas do Tabuleiro: {configuracoes.ColunasTabuleiro}");
                                Console.WriteLine($"Quantidade de Minas: {configuracoes.QuantidadeMinas}");
                                Console.WriteLine();
                            }
                            break;
                        case OpcoesInicioPrograma.MudarConfiguracoes:
                            Console.WriteLine("Opção escolhida: Mudar Configurações");
                            ConfiguracoesJogo.MudarConfiguracoes();
                            break;
                        case OpcoesInicioPrograma.Sair:
                            Console.WriteLine("Opção escolhida: Sair");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
                Console.WriteLine();
            } while (opcaoEscolhida != OpcoesInicioPrograma.Sair);
        }
    }
}

