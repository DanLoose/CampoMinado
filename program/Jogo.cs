using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Jogo
    {
        private Configuracoes configuracoes;
        private Tabuleiro tabuleiro;
        private bool jogoEmAndamento;

        public Jogo(Configuracoes configuracoes)
        {
            this.configuracoes = configuracoes;
        }

        public void Jogar()
        {
            InicializarJogo();

            while (jogoEmAndamento)
            {
                MostrarTabuleiro();
                FazerJogada();
                VerificarFimJogo();
            }

            Console.WriteLine("Fim do jogo!");
        }

        private void InicializarJogo()
        {
            tabuleiro = new Tabuleiro(configuracoes);
            jogoEmAndamento = true;
        }

        private void FazerJogada()
        {
            Console.WriteLine("Informe a linha e coluna para realizar a jogada:");
            int linha = LerInteiro($"(1 - {configuracoes.LinhasTabuleiro}) Linha: ") - 1;
            int coluna = LerInteiro($"(1 - {configuracoes.ColunasTabuleiro}) Coluna: ") - 1;

            tabuleiro.AbrirCelula(linha, coluna);
        }

        private void VerificarFimJogo()
        {
            if (tabuleiro.JogoGanho())
            {
                jogoEmAndamento = false;
                Console.WriteLine("Parabéns! Você venceu o jogo!");
            }
            else if (tabuleiro.JogoPerdido())
            {
                jogoEmAndamento = false;
                Console.WriteLine("Você perdeu! Tente novamente.");
            }
        }

        private void MostrarTabuleiro()
        {
            /*Console.Clear();*/
            Console.WriteLine();
            Console.WriteLine("Tabuleiro:");
            tabuleiro.Imprimir();
            Console.WriteLine();
        }

        private int LerInteiro(string mensagem)
        {
            int valor;
            bool entradaValida = false;

            do
            {
                Console.Write(mensagem);
                string entrada = Console.ReadLine();
                entradaValida = int.TryParse(entrada, out valor);

                if (!entradaValida)
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }
            } while (!entradaValida);

            return valor;
        }
    }

}
