using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
    }
}
