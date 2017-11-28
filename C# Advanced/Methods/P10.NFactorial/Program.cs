using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int factorielCount = int.Parse(Console.ReadLine());

        BigInteger factoriel = CalculateNFactorial(factorielCount);

        Console.WriteLine(factoriel);
    }

    static BigInteger CalculateNFactorial(int factorielCount)
    {
        BigInteger calculatedFactorial = 1;

        for (int i = 1; i <= factorielCount; i++)
        {
            calculatedFactorial *= i;
        }
        return calculatedFactorial;
    }

}