using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;
using ChessGame;

namespace Xadrez_Console
{
    public class ConsoleScreen
    {
        public static void PrintChessPlay(ChessGameplay chessGameplay)
        {
            PrintChessBoard(chessGameplay.Board);
            PrintCapturedChessman(chessGameplay);
            Console.WriteLine($"Turno: {chessGameplay.Round}");
            Console.WriteLine($"Aguardando jogada: {chessGameplay.CurrentPlayer}");
            if (chessGameplay.Xeque)
            {
                Console.WriteLine("Xeque!");
            }
        }
        public static void PrintCapturedChessman(ChessGameplay chessGameplay)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            PrintGroup(chessGameplay.CapturedChessmans(Color.White));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintGroup(chessGameplay.CapturedChessmans(Color.Black));
            Console.ForegroundColor = aux;
        }
        public static void PrintGroup(HashSet<Chessman> chessGroup)
        {
            Console.Write("[");
            foreach (Chessman piece in chessGroup)
            {
                Console.Write($"{piece} ");
            }
            Console.Write("] ");
        }
        public static void PrintChessBoard(ChessBoard chessBoard)
        {
            for(int row = 0; row<chessBoard.Rows; row++)
            {
                Console.Write($"{8 - row} ");
                for(int column=0; column<chessBoard.Columns; column++)
                {
                    PrintChessman(chessBoard.ChessPiece(row, column));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintChessBoard(ChessBoard chessBoard, bool[,] possiblePositions)
        {
            ConsoleColor standardBackground = Console.BackgroundColor;
            ConsoleColor markBackground = ConsoleColor.DarkGray;

            for (int row = 0; row < chessBoard.Rows; row++)
            {
                Console.Write($"{8 - row} ");
                for (int column = 0; column < chessBoard.Columns; column++)
                {
                    if(possiblePositions[row, column])
                    {
                        Console.BackgroundColor = markBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = standardBackground;
                    }
                    PrintChessman(chessBoard.ChessPiece(row, column));
                    Console.BackgroundColor = standardBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static ChessBoardPositioning ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse($"{s[1]}");
            return new ChessBoardPositioning(column, row);
        }
        public static void PrintChessman(Chessman chessman)
        {
            if(chessman == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (chessman.PieceColor == Color.White)
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
                Console.Write(" ");
            }
        }
    }
}
