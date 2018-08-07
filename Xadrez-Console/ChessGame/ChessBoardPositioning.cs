using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace ChessGame
{
    public class ChessBoardPositioning
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public ChessBoardPositioning(char Column, int Row)
        {
            this.Column = Column;
            this.Row = Row;
        }

        public Position toPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

        public override string ToString()
        {
            return $"{Column}{Row}";
        }
    }
}
