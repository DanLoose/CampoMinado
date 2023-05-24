using System;

internal class Program
{

    public static int [,] respostasMatiz;
    public static int[,] usuarioMatriz;
    public static int numBombas;

    private static void Main(string[] args)
    {
        IniciaJogo();
    }

    public static void IniciaJogo()
    {
        numBombas = 30;
        int linha = 10, coluna = 20;

        usuarioMatriz = new int[linha, coluna];
        respostasMatiz = new int[linha, coluna];
        iniciaMatrizNula();
        geraBombas();
        calculaBombasAdjacentes();
        imprimeMatriz(respostasMatiz);
    }

    public static void iniciaMatrizNula()
    {
        for(int i = 0; i<respostasMatiz.GetLength(0); i++)
        {
            for (int j = 0; j<respostasMatiz.GetLength(1); j++)
            {
                respostasMatiz[i, j] = 0;
            }
        }
    }

    public static void geraBombas()
    {
        Random rnd = new Random();
        int bombasAlocadas = 0;

        while (bombasAlocadas < numBombas)
        {
            int x = rnd.Next(0, respostasMatiz.GetLength(0));
            int y = rnd.Next(0, respostasMatiz.GetLength(1));

            if (respostasMatiz[x, y] == 0)
            {
                respostasMatiz[x, y] = 10;
                bombasAlocadas++;
            }
        }
    }

    public static void calculaBombasAdjacentes()
    {
        int linhas = respostasMatiz.GetLength(0);
        int colunas = respostasMatiz.GetLength(1);

        // Varre todos os elementos da matriz
        for (int x = 0; x < linhas; x++)
        {
            for (int y = 0; y < colunas; y++)
            {
                // Ignora células que já contenham bombas
                if (respostasMatiz[x, y] == 10)
                {
                    continue;
                }

                int bombasAdjacentes = 0;

                // Varre as células adjacentes
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        // Ignora a própria célula
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }

                        int vizinhoX = x + i;
                        int vizinhoY = y + j;

                        // Verifica se o vizinho está dentro dos limites da matriz
                        if (vizinhoX >= 0 && vizinhoX < linhas && vizinhoY >= 0 && vizinhoY < colunas)
                        {
                            // Verifica se o vizinho é uma bomba
                            if (respostasMatiz[vizinhoX, vizinhoY] == 10)
                            {
                                bombasAdjacentes++;
                            }
                        }
                    }
                }

                // Atribui o número de bombas adjacentes à célula atual
                respostasMatiz[x, y] = bombasAdjacentes;
            }
        }
    }

    public static void imprimeMatriz(int[,] matriz)
    {
        int linhas = matriz.GetLength(0);
        int colunas = matriz.GetLength(1);

        // encontra qual o maior elemento (em caracteres) da matriz
        int tamanhoMax = 0;
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                int tamanhoElemento = matriz[i, j].ToString().Length;
                if (tamanhoElemento > tamanhoMax)
                {
                    tamanhoMax = tamanhoElemento;
                }
            }
        }

        // transforma todos os elementos em string e imprime 
        // usando a quantidade de caracteres do maior elemento
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                string elementoFormatado = matriz[i, j].ToString().PadLeft(tamanhoMax);
                Console.Write(elementoFormatado + " | ");
            }
            Console.WriteLine();
        }
    }
}