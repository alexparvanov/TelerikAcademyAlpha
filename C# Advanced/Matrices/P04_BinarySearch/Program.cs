using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var limitNum = int.Parse(Console.ReadLine());

        Array.Sort(array);

        int largestNum = Array.BinarySearch(array, limitNum);
        Console.WriteLine(largestNum);
    }
}