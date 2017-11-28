using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int arraySize = int.Parse(Console.ReadLine());

        int[] array = new int[arraySize];

        array = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int indexFound = GetFirstIndexofLargerNumbers(array);
        Console.WriteLine(indexFound);
    }

    static int GetFirstIndexofLargerNumbers(int[] array)
    {
        int index = -1;

        for (int i = 1; i < array.Length - 1; i++)
        {
            if (array[i - 1] < array[i] && array[i] > array[i + 1])
            {
                index = i;
                break;
            }
        }

        return index;
    }
}