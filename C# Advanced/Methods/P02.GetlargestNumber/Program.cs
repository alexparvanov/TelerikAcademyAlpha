using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

        GetMax(inputNums);
    }

    static void GetMax(int[] inputNums)
    {
        int largestNum = Int32.MinValue;
        foreach (var num in inputNums)
        {
            if (num > largestNum)
            {
                largestNum = num;
            }
        }
        Console.WriteLine(largestNum);
    }
}