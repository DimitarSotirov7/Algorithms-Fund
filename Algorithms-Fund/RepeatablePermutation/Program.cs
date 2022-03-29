using System;
using System.Collections.Generic;

namespace Permutation
{
    class Program
    {
        private static List<string> coll = new List<string>() { "A", "B", "B" };

        static void Main(string[] args)
        {
            Permutate(0);
        }

        private static void Permutate(int index)
        {
            if (index == coll.Count)
            {
                Console.WriteLine(String.Join(" ", coll));
                return;
            }

            Permutate(index + 1);
            var swapped = new HashSet<string>() { coll[index] };

            for (int i = index + 1; i < coll.Count; i++)
            {
                if (!swapped.Contains(coll[i]))
                {
                    SwapElements(index, i);
                    Permutate(index + 1);
                    SwapElements(index, i);

                    swapped.Add(coll[i]);
                }
            }
        }

        private static void SwapElements(int index, int i)
        {
            var temp = coll[index];
            coll[index] = coll[i];
            coll[i] = temp;
        }
    }
}
