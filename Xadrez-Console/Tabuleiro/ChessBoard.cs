using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.Tabuleiro
{
    public class ChessBoard
    {

        public int Rows { get; set; }
        public int Columns { get; set; }
        private Chessman[,] chessPiece;

        public ChessBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            chessPiece = new Chessman[rows, columns];
        }

    }
}
