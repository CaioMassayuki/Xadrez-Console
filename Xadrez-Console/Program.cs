using System;
using Xadrez_Console.Tabuleiro;
namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Position position;

            position = new Position(3, 4);

            ChessBoard tab = new ChessBoard(8, 8);

            Console.WriteLine($"Posição: {position}");
        }
    }
}
