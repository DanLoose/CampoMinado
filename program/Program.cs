using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // dados que virão do arquivo:
        int numBombas = 30;
        int linha = 10, coluna = 20;

        // matriz de descobertas do usuario
        int [,] matUsuario = new int[linha,coluna];

        // matriz gabarito
        int[,] matResposta = new int[linha,coluna];

        iniciaMatrizNula(matResposta);
        geraBombas(matResposta, numBombas);
        calculaBombasAdjacentes(matResposta);


        imprimeMatriz(matResposta);
    }

    public static void iniciaMatrizNula(int[,] matResposta)
    {
        for(int i = 0; i<matResposta.GetLength(0); i++)
        {
            for (int j = 0; j<matResposta.GetLength(1); j++)
            {
                matResposta[i, j] = 0;
            }
        }
    }

    public static void geraBombas(int[,] matResposta, int numBombas)
    {
        Random rnd = new Random();
        int bombasAlocadas = 0;

        while (bombasAlocadas < numBombas)
        {
            int x = rnd.Next(0, matResposta.GetLength(0));
            int y = rnd.Next(0, matResposta.GetLength(1));

            if (matResposta[x, y] == 0)
            {
                matResposta[x, y] = 10;
                bombasAlocadas++;
            }
        }
    }

    public static void calculaBombasAdjacentes(int[,] matriz)
    {
        int linhas = matriz.GetLength(0);
        int colunas = matriz.GetLength(1);

        // Varre todos os elementos da matriz
        for (int x = 0; x < linhas; x++)
        {
            for (int y = 0; y < colunas; y++)
            {
                // Ignora células que já contenham bombas
                if (matriz[x, y] == 10)
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
                            if (matriz[vizinhoX, vizinhoY] == 10)
                            {
                                bombasAdjacentes++;
                            }
                        }
                    }
                }

                // Atribui o número de bombas adjacentes à célula atual
                matriz[x, y] = bombasAdjacentes;
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