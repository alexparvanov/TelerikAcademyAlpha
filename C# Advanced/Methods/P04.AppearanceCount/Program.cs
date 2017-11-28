using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int ArrayLength = int.Parse(Console.ReadLine());

        int[] numArray = new int[ArrayLength];

        numArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int numToSearch = int.Parse(Console.ReadLine());

        int appearanceCount = CountAppearanceOfNumberInArray(numArray, numToSearch);
        Console.WriteLine(appearanceCount);
    }

    static int CountAppearanceOfNumberInArray(int[] numArray, int numToSearch)
    {
        int count = 0;

        foreach (var num in numArray)
        {
            if (num == numToSearch)
            {
                count++;
            }
        }
        return count;
    }
}
