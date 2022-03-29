using System;
using System.Collections.Generic;
using System.Linq;

namespace EightQueensPuzzle
{
    class Program
    {
        private static List<Queen> queens = new List<Queen>();
        private static int number = 1;

        static void Main(string[] args)
        {
            var board = new bool[8, 8];

            PutQueen(board, 0);
        }

        private static void PutQueen(bool[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (!Forbidden(row, col))
                {
                    //Pre
                    board[row, col] = true;
                    queens.Add(new Queen()
                    {
                        Row = row,
                        Col = col,
                        LeftDiagonal = row - col,
                        RightDiagonal = row + col
                    });

                    PutQueen(board, row + 1);
                    //Post
                    board[row, col] = false;
                    var queen = queens.FirstOrDefault(x => x.Row == row && x.Col == col &&
                        x.LeftDiagonal == row - col && x.RightDiagonal == row + col);
                    queens.Remove(queen);
                }
            }
        }

        private static bool Forbidden(int row, int col)
        {
            return queens.Any(x => x.Row == row || x.Col == col ||
            x.LeftDiagonal == row - col || x.RightDiagonal == row + col);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
