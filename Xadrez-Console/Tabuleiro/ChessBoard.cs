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

        public void PrintChessPiece(Chessman chessman, Position position)
        {
            if(chessmanExists)
            chessPieces[position.Row, position.Column] = chessman;
            chessman.PiecePosition = position;
        }

        public bool chessmanAlredyExists(Position position)
        {
            validatePosition(position);
            return ChessPiece(position) != null;
        }

        public bool validatePosition(Position position)
        {
            if(position.Row<0 || position.Row>=Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void positionExceptionThrower(Position position)
        {
            if (!validatePosition(position))
            {
                throw new ChessBoardException("Posição inválida!");
            }
        }

    }
}
