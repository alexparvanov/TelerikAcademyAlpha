using System;

class Program
{
    static void Main()
    {
        string nameInput = Console.ReadLine();

        GreetUser(nameInput);
    }

     static void GreetUser(string nameInput)
    {
        Console.WriteLine("Hello, {0}!", nameInput);
    }
}