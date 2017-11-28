using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        int[] firsyPolynom = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] secondPolynom = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] sumOfPolynoms = new int[count];

        AddPolynomials(firsyPolynom, secondPolynom, sumOfPolynoms);

        Console.WriteLine(string.Join(" ", sumOfPolynoms));
    }

    static void AddPolynomials(int[] firsyPolynom, int[] secondPolynom, int[] sumOfPolynoms)
    {
        for (int i = 0; i < firsyPolynom.Length; i++)
        {
            sumOfPolynoms[i] = firsyPolynom[i] + secondPolynom[i];
        }
    }
}