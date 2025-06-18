using System;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
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

            // Roque - jogado especial
            if(qteMovimentos == 0 && !partida.xeque)
            {
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
            }

            if (qteMovimentos == 0 && !partida.xeque)
            {
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 4] = true;
                    }
                }
            }

            return mat;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca peca = tabuleiro.peca(pos);
            return peca != null && peca is Torre && peca.cor == cor && peca.qteMovimentos == 0;
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
