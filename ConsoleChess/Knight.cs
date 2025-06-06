using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Knight : Piece
    {
        public Knight(PieceColor color, string position) : base(color, position)
        {
            Type = "Knight";
        }

        public override List<string> GetAvailableMoves(Piece[,] board)
        {
            var deltas = new (int, int)[] {
            (2, 1), (2, -1), (-2, 1), (-2, -1),
            (1, 2), (1, -2), (-1, 2), (-1, -2)
        };

            List<string> moves = new List<string>();
            int row = 8 - int.Parse(Position[1].ToString());
            int col = Position[0] - 'a';

            foreach (var d in deltas)
            {
                int newRow = row + d.Item1;
                int newCol = col + d.Item2;
                if (IsInsideBoard(newRow, newCol))
                {
                    var target = board[newRow, newCol];
                    if (target == null || target.Color != this.Color)
                        moves.Add(PositionFromCoords(newRow, newCol));
                }
            }

            return moves;
        }
    }
}
