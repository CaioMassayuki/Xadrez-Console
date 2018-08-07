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
                    Console.Clear();
                    ConsoleScreen.PrintChessBoard(chessGameplay.Board);

                    Console.Write("\nOrigem: ");
                    Position origin = ConsoleScreen.ReadChessPosition().toPosition();

                    bool[,] possibleMovements = chessGameplay.Board.ChessPiece(origin).PossibleMovements();

                    Console.Clear();
                    ConsoleScreen.PrintChessBoard(chessGameplay.Board);
                    
                    Console.Write("Destino: ");
                    Position destiny = ConsoleScreen.ReadChessPosition().toPosition();

                    chessGameplay.ExecuteMovement(origin, destiny);
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
