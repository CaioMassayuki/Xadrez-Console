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
        public bool Xeque { get; private set; }

        public ChessGameplay()
        {
            Board = new ChessBoard(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            End = false;
            Chessmans = new HashSet<Chessman>();
            CapturedChessman = new HashSet<Chessman>();
            Xeque = false;
            PutChessmans();
        }
        public Chessman ExecuteMovement(Position origin, Position destiny)
        {
            Chessman chessman = Board.RemoveChessPiece(origin);
            chessman.IncreasePieceMoves();
            Chessman caughtChessman = Board.RemoveChessPiece(destiny);
            Board.PutChessPiece(chessman, destiny);
            if(caughtChessman != null)
            {
                CapturedChessman.Add(caughtChessman);
            }
            return caughtChessman; 
        }

        public void UndoMovement(Position origin, Position destiny, Chessman caughtChessman)
        {
            Chessman piece = Board.RemoveChessPiece(destiny);
            piece.DecreasePieceMoves();
            if(caughtChessman != null)
            {
                Board.PutChessPiece(caughtChessman, destiny);
                CapturedChessman.Remove(caughtChessman);
            }
            Board.PutChessPiece(piece, origin);
        }
        public void PerformPlay(Position origin, Position destiny)
        {
            Chessman caughtChessman = ExecuteMovement(origin, destiny);
            if (IsXequeMate(CurrentPlayer))
            {
                UndoMovement(origin, destiny, caughtChessman);
                throw new ChessBoardException("Você não pode se colocar em xeque!");
            }
            if (IsXequeMate(Enemy(CurrentPlayer)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (TestXequeMate(Enemy(CurrentPlayer)))
            {
                End = true;
            }
            else
            {
                Round++;
                ChangePlayer();
            }
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
        private Color Enemy(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White; 
            }
        }
        private Chessman KingCheck(Color color)
        {
            foreach(Chessman piece in InGameChessmans(color))
            {
                if(piece is King)
                {
                    return piece;
                }
            }
            return null;
        }
        public bool IsXequeMate(Color color)
        {
            Chessman king = KingCheck(color);

            foreach (Chessman piece in InGameChessmans(Enemy(color)))
            {
                bool[,] possibleMovements = piece.PossibleMovements();
                if(possibleMovements[king.PiecePosition.Row, king.PiecePosition.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool TestXequeMate(Color color)
        {
            if (!IsXequeMate(color))
            {
                return false;
            }
            foreach(Chessman piece in InGameChessmans(color))
            {
                bool[,] possibleMovements = piece.PossibleMovements();
                for(int row=0; row<Board.Rows; row++)
                {
                    for(int column=0; column<Board.Columns; column++)
                    {
                        if(possibleMovements[row, column])
                        {
                            Position origin = piece.PiecePosition;
                            Position destiny = new Position(row, column);
                            Chessman capturedChessman = ExecuteMovement(origin, destiny);
                            bool testXeque = IsXequeMate(color);
                            UndoMovement(origin, destiny, capturedChessman);
                            if (!testXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
