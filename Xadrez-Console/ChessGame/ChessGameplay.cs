using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace ChessGame
{
    public class ChessGameplay
    {

        public ChessBoard Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool End { get; private set; }
        private HashSet<Chessman> Chessmans;
        private HashSet<Chessman> CapturedChessman;

        public ChessGameplay()
        {
            Board = new ChessBoard(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            End = false;
            Chessmans = new HashSet<Chessman>();
            CapturedChessman = new HashSet<Chessman>();
            PutChessmans();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Chessman chessman = Board.RemoveChessPiece(origin);
            chessman.IncreasePieceMoves();
            Chessman caughtChessman = Board.RemoveChessPiece(destiny);
            Board.PutChessPiece(chessman, destiny);
            if(caughtChessman != null)
            {
                CapturedChessman.Add(caughtChessman);
            }
        }

        public void PerformPlay(Position origin, Position destiny)
        {
            ExecuteMovement(origin, destiny);
            Round++;
            ChangePlayer();
        }

        public void OriginPositionValidation(Position position)
        {
            if(Board.ChessPiece(position) == null)
            {
                throw new ChessBoardException("Não existe peça na posição de origem escolhida!");
            }
            if (CurrentPlayer != Board.ChessPiece(position).PieceColor)
            {
                throw new ChessBoardException("A peça de origem escolhida não é sua!");
            }
            if (!Board.ChessPiece(position).PossibleMovementsExists())
            {
                throw new ChessBoardException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void DestinyPositionValidation(Position origin, Position destiny)
        {
            if (!Board.ChessPiece(origin).CanMoveTo(destiny))
            {
                throw new ChessBoardException("Posição de Destino inválida!");
            }
        }
        private void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Chessman> CapturedChessmans(Color color)
        {
            HashSet<Chessman> capturedChessman = new HashSet<Chessman>();
            foreach(Chessman chessman in CapturedChessman)
            {
                if(chessman.PieceColor == color)
                {
                    capturedChessman.Add(chessman);
                }
            }
            return capturedChessman;
        }

        public HashSet<Chessman> InGameChessmans(Color color)
        {
            HashSet<Chessman> capturedChessman = new HashSet<Chessman>();
            foreach (Chessman chessman in Chessmans)
            {
                if (chessman.PieceColor == color)
                {
                    capturedChessman.Add(chessman);
                }
            }
            capturedChessman.ExceptWith(CapturedChessmans(color));
            return capturedChessman;
        }

        public void PutNewChessman(char column, int row, Chessman chessman)
        {
            Board.PutChessPiece(chessman, new ChessBoardPositioning(column, row).toPosition());
            Chessmans.Add(chessman);
        }

        private void PutChessmans()
        {
            PutNewChessman('a', 1, new Tower(Board, Color.White));
            PutNewChessman('h', 1, new Tower(Board, Color.White));

            PutNewChessman('a', 8, new Tower(Board, Color.Black));
            PutNewChessman('h', 8, new Tower(Board, Color.Black));

        }

    }
}
