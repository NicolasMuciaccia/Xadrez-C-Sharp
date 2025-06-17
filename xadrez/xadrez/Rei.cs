using System;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // Verificar acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if(tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Verificar nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Verificar direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Verificar sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Verificar abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Verificar sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Verificar esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Verificar noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            return mat;
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
