using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class King : Piece
    {
        public King(PieceColor color, string position) : base(color, position)
        {
            Type = "King";
        }

        public override List<string> GetAvailableMoves(Piece[,] board)
        {
            var directions = new (int, int)[] {
            (1, 0), (-1, 0), (0, 1), (0, -1),
            (1, 1), (-1, -1), (1, -1), (-1, 1)
        };

            List<string> moves = new List<string>();
            int row = 8 - int.Parse(Position[1].ToString());
            int col = Position[0] - 'a';

            foreach (var dir in directions)
            {
                int newRow = row + dir.Item1;
                int newCol = col + dir.Item2;
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
