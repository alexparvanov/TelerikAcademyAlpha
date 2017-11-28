using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        int initLength = input.Length;

        if (initLength != 20)
        {
            input += new string('*', 20 - initLength);
        }
        Console.WriteLine(input);
    }
}