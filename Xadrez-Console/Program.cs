using System;
using Xadrez_Console.Tabuleiro;
namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard chessBoard = new ChessBoard(8, 8);
            ConsoleScreen.PrintChessBoard(chessBoard);

            Console.ReadLine();
        }
    }
}
