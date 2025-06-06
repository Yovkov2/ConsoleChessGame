public class Pawn : Piece
{
    public Pawn(PieceColor color, string position) : base(color, position)
    {
        Type = "Pawn";
    }

    public override List<string> GetAvailableMoves(Piece[,] board)
    {
        List<string> moves = new List<string>();
        int col = Position[0] - 'a';
        int row = 8 - int.Parse(Position[1].ToString());
        int direction = Color == PieceColor.White ? -1 : 1;
        int startRow = Color == PieceColor.White ? 6 : 1;

        if (IsInsideBoard(row + direction, col) && board[row + direction, col] == null)
        {
            moves.Add(PositionFromCoords(row + direction, col));

            if (row == startRow && board[row + 2 * direction, col] == null)
            {
                moves.Add(PositionFromCoords(row + 2 * direction, col));
            }
        }

        for (int deltaCol = -1; deltaCol <= 1; deltaCol += 2)
        {
            int newCol = col + deltaCol;
            int newRow = row + direction;
            if (IsInsideBoard(newRow, newCol))
            {
                var target = board[newRow, newCol];
                if (target != null && target.Color != this.Color)
                {
                    moves.Add(PositionFromCoords(newRow, newCol));
                }
            }
        }

        return moves;
    }
}