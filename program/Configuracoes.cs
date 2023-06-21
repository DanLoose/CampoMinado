using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Configuracoes
    {
        public int LinhasTabuleiro { get; }
        public int ColunasTabuleiro { get; }
        public int QuantidadeMinas { get; }

        public Configuracoes(int linhasTabuleiro, int colunasTabuleiro, int quantidadeMinas)
        {
            LinhasTabuleiro = linhasTabuleiro;
            ColunasTabuleiro = colunasTabuleiro;
            QuantidadeMinas = quantidadeMinas;
        }
    }


}
