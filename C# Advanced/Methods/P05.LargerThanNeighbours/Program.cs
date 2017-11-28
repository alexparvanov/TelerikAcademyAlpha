using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int arraySize = int.Parse(Console.ReadLine());

        int[] array = new int[arraySize];

        array = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int countLargerNumbers = GetCountOfLargerNumbers(array);
        Console.WriteLine(countLargerNumbers);
    }

    static int GetCountOfLargerNumbers(int[] array)
    {
        int count = 0;

        for (int i = 1; i < array.Length - 1; i++)
        {
            if (array[i-1] < array[i] && array[i] > array[i+1])
            {
                count++;
            }
        }

        return count;
    }
}