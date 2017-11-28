using System;
using System.Text;

class Program
{
    static void Main()
    {
        var number = Console.ReadLine();

        string reversedNumber = ReverseNumber(number);
        Console.WriteLine(reversedNumber);
    }

    static string ReverseNumber(string number)
    {
        var sb = new StringBuilder();

        for (int i = number.Length - 1; i >= 0; i--)
        {
            sb.Append(number[i]);
        }
        return sb.ToString();
    }
}