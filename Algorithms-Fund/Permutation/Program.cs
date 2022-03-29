using System;
using System.Collections.Generic;

namespace Permutation
{
    class Program
    {
        private static List<string> coll = new List<string>() { "A", "B", "C" };
        private static List<string> combination = new List<string>();

        static void Main(string[] args)
        {
            Permutate(0);
        }

        private static void Permutate(int index)
        {
            if (index == coll.Count)
            {
                Console.WriteLine(String.Join(" ", combination));
                return;
            }

            for (int i = 0; i < coll.Count; i++)
            {
                if (!combination.Contains(coll[i]))
                {
                    combination.Add(coll[i]);

                    Permutate(index + 1);

                    combination.RemoveAt(combination.Count - 1);
                }
            }
        }
    }
}
