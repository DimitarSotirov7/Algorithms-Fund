using System;
using System.Collections.Generic;
using System.Linq;

namespace Variations
{
    class Program
    {
        private static List<string> coll = new List<string>() { "A", "B", "C", "D" };
        private static int n = 2;
        private static List<string> slot = new List<string>();

        static void Main(string[] args)
        {
            Variation(0);
        }

        private static void Variation(int index)
        {
            if (index == n)
            {
                Console.WriteLine(String.Join(" ", slot));
                return;
            }

            for (int i = 0; i < coll.Count; i++)
            {
                if (!slot.Contains(coll[i]))
                {
                    slot.Add(coll[i]);
                    
                    Variation(index + 1);

                    slot.Remove(slot.FirstOrDefault(x => x == coll[i]));
                }
            }
        }
    }
}
