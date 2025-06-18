using tabuleiro;
using xadrez;

try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();
    while (!partida.terminada)
    {
        try
        {
            Console.Clear();
            Tela.imprimirPartida(partida);

            Posicao origem;
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    origem = Tela.lerPosicaoXadrez().ToPosicao();
                    partida.validarPosicaoDeOrigem(origem);
                    break;
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato inválido! Tente novamente.");
                }
            }

            bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

            Console.Clear();
            Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

            Posicao destino;
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    destino = Tela.lerPosicaoXadrez().ToPosicao();
                    partida.validarPosicaoDeDestino(origem, destino);
                    break;
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato inválido! Tente novamente.");
                }
            }

            partida.realizaJogada(origem, destino);
        }
        catch(TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
    Console.Clear();
    Tela.imprimirPartida(partida);
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();