using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    public class ChessBoardException : Exception
    {
        public ChessBoardException(string message) : base(message)
        {

        }
    }
}
