using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        string word = Console.ReadLine();
        string[] sentences = Console.ReadLine().Split('.').Select(x => x.Trim()).ToArray();

        List<char> separators = new List<char>();
        foreach (var sentence in sentences)
        {
            foreach (char c in sentence)
            {
                if (!Char.IsLetter(c) && !separators.Contains(c))
                    separators.Add(c);
            }
        }

        StringBuilder result = new StringBuilder();
        foreach (var sentence in sentences)
        {
            string[] words = sentence.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            if (words.Contains(word))
                result.Append(sentence + ". ");
        }

        Console.WriteLine(result.ToString().Trim());
    }
}