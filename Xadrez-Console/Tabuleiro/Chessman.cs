﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.Tabuleiro
{
    public class Chessman
    {
        private const int START_PIECE_MOVES = 0;


        public Position PiecePosition { get; set; }
        public Color PieceColor { get; protected set; }
        public int PieceMoves { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Chessman(Position position, ChessBoard board, Color color)
        {
            this.PiecePosition = position;
            this.Board = board;
            this.PieceColor = color;
            this.PieceMoves = START_PIECE_MOVES;
        }

    }
}