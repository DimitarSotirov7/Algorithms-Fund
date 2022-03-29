using System;
using System.Collections.Generic;

namespace RecDemo
{
    class Program
    {
        static void Main()
        {
            //var n = int.Parse(Console.ReadLine());

            //Draw(n);

            //var vector = new int[n];
            //Gen01(vector, 0);

            //Backtracking
            //var rows = int.Parse(Console.ReadLine());
            //var cols = int.Parse(Console.ReadLine());
            //var board = new char[rows, cols];

            //for (int r = 0; r < rows; r++)
            //{
            //    var line = Console.ReadLine();
            //    for (int c = 0; c < line.Length; c++)
            //    {
            //        board[r, c] = line[c];
            //    }
            //}

            //var directions = new List<char>();
            //FindPaths(board, 0, 0, directions, '\0');

        }


        public static void FindPaths(char[,] board, int row, int col, List<char> directions, char direction)
        {
            if (IsOut(board, row, col) ||
                IsWall(board, row, col) ||
                IsVisited(board, row, col))
            {
                return;
            }

            directions.Add(direction);

            if (IsExit(board, row, col))
            {
                Console.WriteLine(String.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            board[row, col] = 'v';

            //Up
            FindPaths(board, row - 1, col, directions, 'U');
            //Right
            FindPaths(board, row, col + 1, directions, 'R');
            //Down
            FindPaths(board, row + 1, col, directions, 'D');
            //Left
            FindPaths(board, row, col - 1, directions, 'L');

            board[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }

        public static bool IsOut(char[,] board, int row, int col)
        {
            return row < 0 || row >= board.GetLength(0) ||
                col < 0 || col >= board.GetLength(1);
        }

        public static bool IsWall(char[,] board, int row, int col)
        {
            return board[row, col] == '*';
        }

        public static bool IsVisited(char[,] board, int row, int col)
        {
            return board[row, col] == 'v';
        }

        public static bool IsExit(char[,] board, int row, int col)
        {
            return board[row, col] == 'e';
        }

        public static void Gen01(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(String.Join(' ', vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01(vector, index + 1);
            }
        }

        public static void Draw(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*' , n));

            Draw(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
