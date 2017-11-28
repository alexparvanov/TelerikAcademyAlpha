using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int minimum = CalculateMinimumNumber(array);

        int maximum = CalculateMaximumNumber(array);

        double average = CalculateAverageNumber(array);

        int sum = CalculateSumOfNumbers(array);

        long product = CalculateProductOfNumbers(array);

        Console.WriteLine(minimum);
        Console.WriteLine(maximum);
        Console.WriteLine("{0:f2}", average);
        Console.WriteLine(sum);
        Console.WriteLine(product);
    }

     static long CalculateProductOfNumbers(int[] array)
     {
         long productOfNums = 1;

         for (int i = 0; i < array.Length; i++)
         {
             productOfNums *= array[i];
         }

         return productOfNums;
     }

    static int CalculateSumOfNumbers(int[] array)
     {
         int sum = array.Sum();

         return sum;
     }

    static double CalculateAverageNumber(int[] array)
    {
        double averageNum = array.Average();

        return averageNum;
    }

    static int CalculateMaximumNumber(int[] array)
    {
        int maximum = int.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maximum)
            {
                maximum = array[i];
            }
        }

        return maximum;
    }

    static int CalculateMinimumNumber(int[] array)
    {
        int minimum = int.MaxValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < minimum)
            {
                minimum = array[i];
            }
        }

        return minimum;
    }
}
