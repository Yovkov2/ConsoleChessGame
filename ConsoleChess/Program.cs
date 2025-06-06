using System;
using ConsoleChess;

namespace ConsoleChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            PieceColor currentPlayer = PieceColor.White;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Текущ играч: " + currentPlayer);
                PrintBoard(board);

                Console.WriteLine("Въведи ход (пример: e2 e4):");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                var parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Невалиден формат на хода.");
                    Console.ReadKey();
                    continue;
                }

                bool success = board.MovePiece(parts[0], parts[1], currentPlayer);
                if (!success)
                {
                    Console.WriteLine("Невалиден ход!");
                    Console.ReadKey();
                    continue;
                }

                currentPlayer = currentPlayer == PieceColor.White ? PieceColor.Black : PieceColor.White;
            }
        }

        static void PrintBoard(Board board)
        {
            for (int row = 0; row < 8; row++)
            {
                Console.Write(8 - row + " ");
                for (int col = 0; col < 8; col++)
                {
                    var piece = board.Grid[row, col];
                    if (piece == null)
                        Console.Write(". ");
                    else
                    {
                        char symbol = piece.Type[0];
                        if (piece.Color == PieceColor.Black)
                            symbol = char.ToLower(symbol);
                        Console.Write(symbol + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
    }
}