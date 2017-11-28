using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        var sb = new StringBuilder();

        char previous = input[0];
        sb.Append(previous);
        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (currentChar == previous)
            {
                continue;
            }
            else
            {
                sb.Append(input[i]);
                previous = input[i];
            }
        }

        Console.WriteLine(sb.ToString());
    }
}
