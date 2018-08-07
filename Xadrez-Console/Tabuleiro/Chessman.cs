using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    public abstract class Chessman
    {
        private const int START_PIECE_MOVES = 0;


        public Position PiecePosition { get; set; }
        public Color PieceColor { get; protected set; }
        public int PieceMoves { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Chessman(ChessBoard board, Color color)
        {
            this.PiecePosition = null;
            this.Board = board;
            this.PieceColor = color;
            this.PieceMoves = START_PIECE_MOVES;
        }

        public void IncreasePieceMoves()
        {
            PieceMoves++;
        }

        public abstract bool[,] PossibleMovements();
    }
}
