using System;
using System.Collections.Generic;
using System.Linq;

namespace task06_GirlsGoneWild
{
    class Program
    {
        private static int shirts;
        private static char[] skirtLetters;
        private static HashSet<string> combinations = new HashSet<string>();
        private static int girlsCount;
        private static int firstShirt;
        private static List<int> takenShirts = new List<int>();
        private static List<int> takenSkirts = new List<int>();

        static void Main()
        {
            shirts = int.Parse(Console.ReadLine());
            skirtLetters = Console.ReadLine().ToCharArray();
            girlsCount = int.Parse(Console.ReadLine());
            GenerateCombination();
            Console.WriteLine(combinations.Count);
            Console.WriteLine(string.Join(Environment.NewLine, combinations.OrderBy(o => o)));
        }

        private static void GenerateCombination(int depth = 0, string currentCombination = "")
        {
            depth++;
            if (depth > girlsCount)
            {
                combinations.Add(currentCombination);
                return;
            }
            string currentLocalCombination = currentCombination;

            if (depth < 2)
            {
                for (var i = 0; i < shirts; i++)
                {
                    takenShirts.Add(i);
                    firstShirt = i;
                    for (var j = 0; j < skirtLetters.Length; j++)
                    {
                        takenSkirts.Add(j);
                        currentCombination = currentLocalCombination + $"{i}{skirtLetters[j]}";
                        GenerateCombination(depth, currentCombination);
                        takenSkirts.Remove(j);
                    }
                    takenShirts.Remove(i);
                }
            }

            else
            {
                for (var i = firstShirt + depth-1; i < shirts; i++)
                {
                    if (takenShirts.Contains(i))
                    {
                        continue;
                    }
                    takenShirts.Add(i);
                    for (var j = 0; j < skirtLetters.Length; j++)
                    {
                        if (takenSkirts.Contains(j))
                        {
                            continue;
                        }
                        takenSkirts.Add(j);
                        currentCombination = currentLocalCombination + $"-{i}{skirtLetters[j]}";

                        GenerateCombination(depth, currentCombination);
                        takenSkirts.Remove(j);
                    }
                    takenShirts.Remove(i);
                }
            }
        }
    }
}