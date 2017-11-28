using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        Console.WriteLine(Regex.Replace(input, @"<a href=""(.*?)"">(.*?)</a>", @"[$2]($1)"));
    }
}