using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.Tabuleiro
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

    }
}
