using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    public class ChessBoard
    {

        public int Rows { get; set; }
        public int Columns { get; set; }
        private Chessman[,] chessPieces;

        public ChessBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            chessPieces = new Chessman[rows, columns];
        }

        public Chessman ChessPiece(int row, int column)
        {
            return chessPieces[row, column];
        }
        public Chessman ChessPiece(Position position)
        {
            return chessPieces[position.Row, position.Column];
        }

        public void PutChessPiece(Chessman chessman, Position position)
        {
            if (ChessmanAlreadyExists(position))
            {
                throw new ChessBoardException("Já existe uma peça nessa posição!");
            }
            chessPieces[position.Row, position.Column] = chessman;
            chessman.PiecePosition = position;
        }

        public Chessman RemoveChessPiece(Position position)
        {
            if(ChessPiece(position) == null)
            {
                return null;
            }
            Chessman chessman = ChessPiece(position);
            chessman.PiecePosition = null;
            chessPieces[position.Row, position.Column] = null;
            return chessman;
        }

        public bool ChessmanAlreadyExists(Position position)
        {
            ValidatePosition(position);
            return ChessPiece(position) != null;
        }

        public bool ValidatePosition(Position position)
        {
            if(position.Row<0 || position.Row>=Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void PositionExceptionThrower(Position position)
        {
            if (!ValidatePosition(position))
            {
                throw new ChessBoardException("Posição inválida!");
            }
        }

    }
}
