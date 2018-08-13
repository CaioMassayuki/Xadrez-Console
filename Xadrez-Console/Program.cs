using System;
using Tabuleiro;
using ChessGame;

namespace Xadrez_Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ChessGameplay chessGameplay = new ChessGameplay();

                while (!chessGameplay.End)
                {
                    try
                    {
                        Console.Clear();
                        ConsoleScreen.PrintChessPlay(chessGameplay);

                        Console.Write("\nOrigem: ");
                        Position origin = ConsoleScreen.ReadChessPosition().toPosition();
                        chessGameplay.OriginPositionValidation(origin);

                        bool[,] possibleMovements = chessGameplay.Board.ChessPiece(origin).PossibleMovements();

                        Console.Clear();
                        ConsoleScreen.PrintChessBoard(chessGameplay.Board, possibleMovements);

                        Console.Write("Destino: ");
                        Position destiny = ConsoleScreen.ReadChessPosition().toPosition();
                        chessGameplay.DestinyPositionValidation(origin, destiny);

                        chessGameplay.PerformPlay(origin, destiny);
                    }
                    catch(ChessBoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }

            }
            catch(ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
