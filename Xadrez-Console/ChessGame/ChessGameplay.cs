using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace ChessGame
{
    public class ChessGameplay
    {

        public ChessBoard Board { get; private set; }
        private int Round;
        private Color CurrentPlayer;
        public bool End { get; private set; }

        public ChessGameplay()
        {
            Board = new ChessBoard(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            End = false;
            PutChessmans();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Chessman chessman = Board.RemoveChessPiece(origin);
            chessman.IncreasePieceMoves();
            Chessman caughtChessman = Board.RemoveChessPiece(destiny);
            Board.PutChessPiece(chessman, destiny);
        }

        private void PutChessmans()
        {
            Board.PutChessPiece(new Tower(Board, Color.White), new ChessBoardPositioning('a', 1).toPosition());
            Board.PutChessPiece(new Tower(Board, Color.White), new ChessBoardPositioning('h', 1).toPosition());

            Board.PutChessPiece(new Tower(Board, Color.Black), new ChessBoardPositioning('a', 8).toPosition());
            Board.PutChessPiece(new Tower(Board, Color.Black), new ChessBoardPositioning('h', 8).toPosition());
        }

    }
}
