using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace Xadrez_Console
{
    public class ConsoleScreen
    {
        public static void PrintChessBoard(ChessBoard chessBoard)
        {
            for(int row = 0; row<chessBoard.Rows; row++)
            {
                Console.Write($"{8 - row} ");
                for(int column=0; column<chessBoard.Columns; column++)
                {
                    if (chessBoard.ChessPiece(row, column) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printChessman(chessBoard.ChessPiece(row, column));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printChessman(Chessman chessman)
        {
            if(chessman.PieceColor == Color.White)
            {
                Console.Write(chessman);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(chessman);
                Console.ForegroundColor = aux;
            }
        }
    }
}
