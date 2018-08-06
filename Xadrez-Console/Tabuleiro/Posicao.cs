using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.Tabuleiro
{
    public class Position
    {
        public int row { get; set; }
        public int column { get; set; }

        public Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
        
    }
}
