using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace ChessGame
{
    public class ChessGameplay
    {

        public ChessBoard Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
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

        public void PerformPlay(Position origin, Position destiny)
        {
            ExecuteMovement(origin, destiny);
            Round++;
            ChangePlayer();
        }

        public void OriginPositionValidation(Position position)
        {
            if(Board.ChessPiece(position) == null)
            {
                throw new ChessBoardException("Não existe peça na posição de origem escolhida!");
            }
            if (CurrentPlayer != Board.ChessPiece(position).PieceColor)
            {
                throw new ChessBoardException("A peça de origem escolhida não é sua!");
            }
            if (!Board.ChessPiece(position).PossibleMovementsExists())
            {
                throw new ChessBoardException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void DestinyPositionValidation(Position origin, Position destiny)
        {
            if (!Board.ChessPiece(origin).CanMoveTo(destiny))
            {
                throw new ChessBoardException("Posição de Destino inválida!");
            }
        }
        private void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
