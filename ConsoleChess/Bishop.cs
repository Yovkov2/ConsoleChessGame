using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color, string position) : base(color, position)
        {
            Type = "Bishop";
        }

        public override List<string> GetAvailableMoves(Piece[,] board)
        {
            return GetLinearMoves(board, new (int, int)[] { (1, 1), (-1, -1), (1, -1), (-1, 1) });
        }
    }
}
