using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBenom(row, col));
        }

        private static int GetBenom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return GetBenom(row - 1, col - 1) + GetBenom(row - 1, col);
        }
    }
}
