using System;
using System.Linq;

namespace CokiSkoki
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var buildings = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] jumps = new int[n];

            for (int i = n - 1; i > -1; i--)
            {
                int j = i + 1;
                while (j < n)
                {
                    if (buildings[i] < buildings[j])
                    {
                        jumps[i] = jumps[j] + 1;
                        break;
                    }
                    else if (jumps[j] == 0)
                    {
                        break;
                    }

                    j++;
                }
            }

            Console.WriteLine(jumps.Max());
            Console.WriteLine(string.Join(" ", jumps));
        }
    }
}
