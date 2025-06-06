public abstract class Piece
{
    public PieceColor Color { get; set; }
    public string Position { get; set; }
    public string Type { get; set; }

    public Piece(PieceColor color, string position)
    {
        Color = color;
        Position = position;
        Type = "Unknown";
    }

    public abstract List<string> GetAvailableMoves(Piece[,] board);

    protected bool IsInsideBoard(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    protected string PositionFromCoords(int row, int col)
    {
        char file = (char)('a' + col);
        int rank = 8 - row;
        return $"{file}{rank}";
    }

    protected List<string> GetLinearMoves(Piece[,] board, (int, int)[] directions)
    {
        List<string> moves = new List<string>();
        int row = 8 - int.Parse(Position[1].ToString());
        int col = Position[0] - 'a';

        foreach (var dir in directions)
        {
            int r = row + dir.Item1;
            int c = col + dir.Item2;
            while (IsInsideBoard(r, c))
            {
                var target = board[r, c];
                if (target == null)
                {
                    moves.Add(PositionFromCoords(r, c));
                }
                else
                {
                    if (target.Color != this.Color)
                        moves.Add(PositionFromCoords(r, c));
                    break;
                }

                r += dir.Item1;
                c += dir.Item2;
            }
        }

        return moves;
    }
}