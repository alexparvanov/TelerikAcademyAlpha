using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        int leftBracketCount = 0;
        int rightBracketCount = 0;

        foreach (var character in input)
        {
            if (character == '(')
            {
                leftBracketCount++;
            }
            else if (character == ')')
            {
                rightBracketCount++;
            }
        }

        if (leftBracketCount == rightBracketCount)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }
    }
}