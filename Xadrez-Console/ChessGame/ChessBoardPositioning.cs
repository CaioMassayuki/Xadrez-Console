using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace ChessGame
{
    class ChessBoardPositioning
    {
        public char Column { get; set; }
        public char Row { get; set; }

        public ChessBoardPositioning(char Column, char Row)
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
