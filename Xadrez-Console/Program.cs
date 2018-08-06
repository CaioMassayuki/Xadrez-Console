using System;
using Xadrez_Console.Tabuleiro;
using ChessGame;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard chessBoard = new ChessBoard(8, 8);

            chessBoard.PrintChessPiece(new Tower(chessBoard, Color.Black), new Position(0, 0));
            chessBoard.PrintChessPiece(new Tower(chessBoard, Color.Black), new Position(1, 3));
            chessBoard.PrintChessPiece(new King(chessBoard, Color.Black), new Position(2, 4));



            ConsoleScreen.PrintChessBoard(chessBoard);

            Console.ReadLine();
        }
    }
}
