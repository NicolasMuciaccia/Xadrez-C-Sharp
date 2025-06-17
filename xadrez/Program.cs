using tabuleiro;
using xadrez;

Tabuleiro tab = new Tabuleiro(8, 8);

tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 7));
tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 4));

Tela.imprimirTabuleiro(tab);
Console.ReadLine();