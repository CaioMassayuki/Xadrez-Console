using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace ChessGame
{
    class Bishop : Chessman
    {
        public Bishop(ChessBoard chessBoard, Color color) : base(chessBoard, color)
        {

        }
        public override string ToString()
        {
            return $"B";
        }
        private bool CanMove(Position position)
        {
            Chessman chessman = Board.ChessPiece(position);
            return chessman == null || chessman.PieceColor != PieceColor;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] chessmanPossibleMoves = new bool[Board.Rows, Board.Columns];

            Position movementPosition = new Position(0, 0);

            movementPosition.SetValues(PiecePosition.Row - 1, PiecePosition.Column - 1);
            while (Board.ValidatePosition(movementPosition) && CanMove(movementPosition))
            {
                chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                if (Board.ChessPiece(movementPosition) != null && Board.ChessPiece(movementPosition).PieceColor != PieceColor)
                {
                    break;
                }
                movementPosition.SetValues(PiecePosition.Row - 1, PiecePosition.Column - 1);
            }

            movementPosition.SetValues(PiecePosition.Row - 1, PiecePosition.Column + 1);
            while (Board.ValidatePosition(movementPosition) && CanMove(movementPosition))
            {
                chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                if (Board.ChessPiece(movementPosition) != null && Board.ChessPiece(movementPosition).PieceColor != PieceColor)
                {
                    break;
                }
                movementPosition.SetValues(PiecePosition.Row - 1, PiecePosition.Column + 1);
            }

            movementPosition.SetValues(PiecePosition.Row + 1, PiecePosition.Column + 1);
            while (Board.ValidatePosition(movementPosition) && CanMove(movementPosition))
            {
                chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                if (Board.ChessPiece(movementPosition) != null && Board.ChessPiece(movementPosition).PieceColor != PieceColor)
                {
                    break;
                }
                movementPosition.SetValues(PiecePosition.Row + 1, PiecePosition.Column + 1);
            }

            movementPosition.SetValues(PiecePosition.Row + 1, PiecePosition.Column - 1);
            while (Board.ValidatePosition(movementPosition) && CanMove(movementPosition))
            {
                chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                if (Board.ChessPiece(movementPosition) != null && Board.ChessPiece(movementPosition).PieceColor != PieceColor)
                {
                    break;
                }
                movementPosition.SetValues(PiecePosition.Row + 1, PiecePosition.Column - 1);
            }

            return chessmanPossibleMoves;
        }
    }
}
