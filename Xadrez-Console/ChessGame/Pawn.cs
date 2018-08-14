using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace ChessGame
{
    class Pawn : Chessman
    {
        public Pawn(ChessBoard chessBoard, Color color) : base(chessBoard, color)
        {

        }
        public override string ToString()
        {
            return $"P";
        }
        private bool ExistEnemy(Position position)
        {
            Chessman chessman = Board.ChessPiece(position);
            return chessman != null && chessman.PieceColor != PieceColor;
        }
        private bool Empty(Position position)
        {
            return Board.ChessPiece(position) == null;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] chessmanPossibleMoves = new bool[Board.Rows, Board.Columns];

            Position movementPosition = new Position(0, 0);

            if (PieceColor == Color.White)
            {
                movementPosition.SetValues(PiecePosition.Row - 1, PiecePosition.Column);
                if (Board.ValidatePosition(movementPosition) && Empty(movementPosition))
                {
                    chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                }
                movementPosition.SetValues(PiecePosition.Row - 2, PiecePosition.Column);
                if (Board.ValidatePosition(movementPosition) && Empty(movementPosition) && PieceMoves == 0)
                {
                    chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                }
                movementPosition.SetValues(PiecePosition.Row - 1, PiecePosition.Column - 1);
                if (Board.ValidatePosition(movementPosition) && ExistEnemy(movementPosition))
                {
                    chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                }
                movementPosition.SetValues(PiecePosition.Row - 1, PiecePosition.Column + 1);
                if (Board.ValidatePosition(movementPosition) && ExistEnemy(movementPosition))
                {
                    chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                }
            }
            else
            {
                movementPosition.SetValues(PiecePosition.Row + 1, PiecePosition.Column);
                if (Board.ValidatePosition(movementPosition) && Empty(movementPosition))
                {
                    chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                }
                movementPosition.SetValues(PiecePosition.Row + 2, PiecePosition.Column);
                if (Board.ValidatePosition(movementPosition) && Empty(movementPosition) && PieceMoves == 0)
                {
                    chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                }
                movementPosition.SetValues(PiecePosition.Row + 1, PiecePosition.Column + 1);
                if (Board.ValidatePosition(movementPosition) && ExistEnemy(movementPosition))
                {
                    chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                }
                movementPosition.SetValues(PiecePosition.Row + 1, PiecePosition.Column - 1);
                if (Board.ValidatePosition(movementPosition) && ExistEnemy(movementPosition))
                {
                    chessmanPossibleMoves[movementPosition.Row, movementPosition.Column] = true;
                }
            }

            return chessmanPossibleMoves;
        }

    }
}
