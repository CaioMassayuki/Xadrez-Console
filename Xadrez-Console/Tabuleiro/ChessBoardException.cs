using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    class ChessBoardException : Exception
    {
        public ChessBoardException(string message) : base(message)
        {

        }
    }
}
