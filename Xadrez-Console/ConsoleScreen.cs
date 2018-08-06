using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console
{
    public class ConsoleScreen
    {
        public static void PrintChessBoard(ChessBoard chessBoard)
        {
            for(int row = 0; row<chessBoard.Rows; row++)
            {
                for(int column=0; column<chessBoard.Columns; column++)
                {
                    if (chessBoard.ChessPiece(row, column) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{chessBoard.ChessPiece(row, column)} ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
