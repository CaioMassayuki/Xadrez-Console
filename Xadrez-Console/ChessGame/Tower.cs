using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.Tabuleiro;

namespace ChessGame
{
    public class Tower : Chessman
    {

        public Tower(ChessBoard chessBoard, Color color) : base(chessBoard, color)
        {

        }

        public override string ToString()
        {
            return $"T";
        }

    }
}
