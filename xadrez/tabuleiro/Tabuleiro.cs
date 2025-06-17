namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        public Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (temPeca(pos))
            {
                Console.WriteLine("Já existe uma peça nessa posição (" + pos +")");
                return;
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        private bool temPeca(Posicao pos)
        {
            return peca(pos.linha, pos.coluna) != null;
        }
    }
}
