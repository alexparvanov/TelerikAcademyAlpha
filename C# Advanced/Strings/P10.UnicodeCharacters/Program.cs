using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine();

        var charArr = input.ToCharArray();

        for (int i = 0; i < charArr.Length; i++)
        {
            Console.Write("\\u{0:X4}",(int)charArr[i]);
        }
        Console.WriteLine();
    }
}