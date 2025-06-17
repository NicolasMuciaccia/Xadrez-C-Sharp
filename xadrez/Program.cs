using tabuleiro;
using xadrez;

try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();
    while (!partida.terminada)
    {
        Console.Clear();
        Tela.imprimirTabuleiro(partida.tab);

        Console.WriteLine();
        Console.Write("Origem: ");
        Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();

        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

        Console.Clear();
        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

        Console.WriteLine();
        Console.Write("Destino: ");
        Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();

        partida.executarMovimento(origem, destino);
    }
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();