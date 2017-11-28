using System;
using System.Collections.Generic;

class Program
{
    static int previousNum = int.MinValue;

    static void Main()
    {
        List<int> numsToPrint = new List<int>();

        numsToPrint.Add(1);
        for (int i = 0; i < 10; i++)
        {
            try
            {
                ReadNumber(1, 100, numsToPrint);
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
                return;
            }
        }

        numsToPrint.Add(100);
        Console.WriteLine(string.Join(" < ", numsToPrint));
    }

    static void ReadNumber(int start, int end, List<int> numsToPrint)
    {
        int currentNum = int.Parse(Console.ReadLine());
        if (currentNum > start && currentNum < end && currentNum > previousNum)
        {
            numsToPrint.Add(currentNum);
            previousNum = currentNum;
        }
        else
        {
            throw new Exception("Exception");
        }
    }
}