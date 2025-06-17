using tabuleiro;
using xadrez;

try
{
    Tabuleiro tab = new Tabuleiro(8, 8);

    tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
    tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 7));
    tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 4));

    tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(7, 0));
    tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(7, 7));
    tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(7, 4));

    Tela.imprimirTabuleiro(tab);
    Console.ReadLine();
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();