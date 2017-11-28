using System;

class Program
{
    static void Main()
    {
        string pattern = Console.ReadLine().ToLower();
        string input = Console.ReadLine().ToLower();
        int count = 0;
        do
        {
            int index = input.IndexOf(pattern);
            if (index == -1)
            {
                break;
            }
            count++;
            input = input.Substring(index + pattern.Length);
        } while (true);
        Console.WriteLine(count);
    }
}