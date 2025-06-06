using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Queen : Piece
    {
        public Queen(PieceColor color, string position) : base(color, position)
        {
            Type = "Queen";
        }

        public override List<string> GetAvailableMoves(Piece[,] board)
        {
            return GetLinearMoves(board, new (int, int)[] {
            (1, 0), (-1, 0), (0, 1), (0, -1),
            (1, 1), (-1, -1), (1, -1), (-1, 1)
        });
        }
    }
}
