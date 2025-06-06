using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Board
    {
        public Piece[,] Grid { get; private set; }

        public Board() 
        {
            Grid = new Piece[8, 8];
            InitializePieces();
        }
        private void InitializePieces()
        {
            for (int col = 0; col < 8; col++)
            {
                Grid[6, col] = new Pawn(PieceColor.White, PositionFromCoords(6, col));
                Grid[1, col] = new Pawn(PieceColor.Black, PositionFromCoords(1, col));
            }
            //rocks
            Grid[7, 0] = new Rook(PieceColor.White, "a1");
            Grid[7, 7] = new Rook(PieceColor.White, "h1");
            Grid[0, 0] = new Rook(PieceColor.Black, "a8");
            Grid[0, 7] = new Rook(PieceColor.Black, "h8");
            //knights
            Grid[7, 1] = new Knight(PieceColor.White, "b1");
            Grid[7, 6] = new Knight(PieceColor.White, "g1");
            Grid[0, 1] = new Knight(PieceColor.Black, "b8");
            Grid[0, 6] = new Knight(PieceColor.Black, "g8");

            //bishops
            Grid[7, 2] = new Bishop(PieceColor.White, "c1");
            Grid[7, 5] = new Bishop(PieceColor.White, "f1");
            Grid[0, 2] = new Bishop(PieceColor.Black, "c8");
            Grid[0, 5] = new Bishop(PieceColor.Black, "f8");

            //queen
            Grid[7, 3] = new Queen(PieceColor.White, "d1");
            Grid[0, 3] = new Queen(PieceColor.Black, "d8");

            //king
            Grid[7, 4] = new King(PieceColor.White, "e1");
            Grid[0, 4] = new King(PieceColor.Black, "e8");
        }
        private string PositionFromCoords(int row, int col)
        {
            char file = (char)('a' + col);
            int rank = 8 - row;
            return $"{file}{rank}";
        }
        public bool MovePiece(string from, string to, PieceColor playerColor)
        {
            var fromCoords = PositionToCoords(from);
            var toCoords = PositionToCoords(to);

            if (fromCoords == null || toCoords == null)
                return false;

            int fromRow = fromCoords.Value.row;
            int fromCol = fromCoords.Value.col;
            int toRow = toCoords.Value.row;
            int toCol = toCoords.Value.col;

            var piece = Grid[fromRow, fromCol];

            if (piece == null)
                return false;

            if (piece.Color != playerColor)
                return false;

            var availableMoves = piece.GetAvailableMoves(Grid);
            if (!availableMoves.Contains(to))
                return false;

            Grid[toRow, toCol] = piece;
            Grid[fromRow, fromCol] = null;
            piece.Position = to;

            return true;
        }
        public (int row, int col)? PositionToCoords(string position)
        {
            if (position.Length != 2) return null;

            char file = position[0];
            char rank = position[1];

            if (file < 'a' || file > 'h') return null;
            if (rank < '1' || rank > '8') return null;

            int col = file - 'a';
            int row = 8 - (rank - '0');
            return (row, col);
        }

    }
}
