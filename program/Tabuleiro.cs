using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Tabuleiro
    {
        private Configuracoes configuracoes;
        private Celula[,] celulas;
        private int celulasAbertas;

        public Tabuleiro(Configuracoes configuracoes)
        {
            this.configuracoes = configuracoes;
            celulas = new Celula[configuracoes.LinhasTabuleiro, configuracoes.ColunasTabuleiro];
            celulasAbertas = 0;

            InicializarCelulas();
            DistribuirMinas();
        }

        private void InicializarCelulas()
        {
            for (int linha = 0; linha < configuracoes.LinhasTabuleiro; linha++)
            {
                for (int coluna = 0; coluna < configuracoes.ColunasTabuleiro; coluna++)
                {
                    celulas[linha, coluna] = new Celula();
                }
            }
        }

        private void DistribuirMinas()
        {
            int minasRestantes = configuracoes.QuantidadeMinas;
            Random random = new Random();

            while (minasRestantes > 0)
            {
                int linha = random.Next(configuracoes.LinhasTabuleiro);
                int coluna = random.Next(configuracoes.ColunasTabuleiro);

                if (!celulas[linha, coluna].TemMina)
                {
                    celulas[linha, coluna].DefinirMina();
                    minasRestantes--;
                }
            }
        }

        public void AbrirCelula(int linha, int coluna)
        {
            if (!CelulaExiste(linha, coluna))
            {
                Console.WriteLine("Posição inválida. Tente novamente.");
                return;
            }

            Celula celula = celulas[linha, coluna];

            if (celula.Estado == EstadoCelula.Aberta)
            {
                Console.WriteLine("Essa célula já foi aberta. Tente outra.");
                return;
            }

            if (celula.TemMina)
            {
                celula.Abrir();
                Console.WriteLine("BOOM! Você acertou uma mina. Game over.");
                return;
            }

            AbrirCelulasAdjacentes(linha, coluna);
        }

        private void AbrirCelulasAdjacentes(int linha, int coluna)
        {
            Celula celula = celulas[linha, coluna];
            celula.Abrir();
            celulasAbertas++;

            int minasAdjacentes = ContarMinasAdjacentes(linha, coluna);

            if (minasAdjacentes == 0)
            {
                for (int i = linha - 1; i <= linha + 1; i++)
                {
                    for (int j = coluna - 1; j <= coluna + 1; j++)
                    {
                        if (CelulaExiste(i, j) && celulas[i, j].Estado == EstadoCelula.Fechada)
                        {
                            AbrirCelulasAdjacentes(i, j);
                        }
                    }
                }
            }
        }

        private int ContarMinasAdjacentes(int linha, int coluna)
        {
            int minasAdjacentes = 0;

            for (int i = linha - 1; i <= linha + 1; i++)
            {
                for (int j = coluna - 1; j <= coluna + 1; j++)
                {
                    if (CelulaExiste(i, j) && celulas[i, j].TemMina)
                    {
                        minasAdjacentes++;
                    }
                }
            }

            return minasAdjacentes;
        }

        public bool JogoGanho()
        {
            int totalCelulas = configuracoes.LinhasTabuleiro * configuracoes.ColunasTabuleiro;
            int celulasSemMina = totalCelulas - configuracoes.QuantidadeMinas;

            return celulasAbertas == celulasSemMina;
        }

        public bool JogoPerdido()
        {
            foreach (Celula celula in celulas)
            {
                if (celula.TemMina && celula.Estado == EstadoCelula.Aberta)
                {
                    return true;
                }
            }

            return false;
        }

        public void Imprimir()
        {
            for (int linha = 0; linha < configuracoes.LinhasTabuleiro; linha++)
            {
                for (int coluna = 0; coluna < configuracoes.ColunasTabuleiro; coluna++)
                {
                    Celula celula = celulas[linha, coluna];

                    if (celula.Estado == EstadoCelula.Aberta)
                    {
                        if (celula.TemMina)
                        {
                            Console.Write("X ");
                        }
                        else
                        {
                            int minasAdjacentes = ContarMinasAdjacentes(linha, coluna);
                            Console.Write(minasAdjacentes + " ");
                        }
                    }
                    else if (celula.Estado == EstadoCelula.Marcada)
                    {
                        Console.Write("M ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }

        private bool CelulaExiste(int linha, int coluna)
        {
            return linha >= 0 && linha < configuracoes.LinhasTabuleiro &&
                   coluna >= 0 && coluna < configuracoes.ColunasTabuleiro;
        }
    }
}
