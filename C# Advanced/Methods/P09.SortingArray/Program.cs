using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        int arrayLength = int.Parse(Console.ReadLine());

        int[] array = new int[arrayLength];

        array = Console.ReadLine().Split().Select(int.Parse).ToArray();

        SortArray(array);
    }

    static void SortArray(int[] array)
    {
        int[] sortedArray = new int[array.Length];

        int currentElement = 0;

        int currentLowestNum = int.MaxValue;
        int currentLowestPosition = 0;

        for (int j = 0; j < array.Length; j++)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != int.MinValue && array[i] < currentLowestNum)
                {
                    currentLowestNum = array[i];
                    currentLowestPosition = i;
                }
            }
            array[currentLowestPosition] = int.MinValue;
            sortedArray[currentElement] = currentLowestNum;
            currentLowestNum = int.MaxValue;
            currentElement++;
        }


        Console.WriteLine(string.Join(" ", sortedArray));
    }
}