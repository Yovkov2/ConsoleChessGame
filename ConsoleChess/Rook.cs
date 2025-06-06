using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Rook : Piece
    {
        public Rook(PieceColor color, string position) : base(color, position)
        {
            Type = "Rook";
        }

        public override List<string> GetAvailableMoves(Piece[,] board)
        {
            return GetLinearMoves(board, new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) });
        }
    }
}
