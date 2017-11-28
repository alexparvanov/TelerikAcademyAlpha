using System;

class Program
{
    static void Main()
    {
        try
        {
            double number = double.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new Exception();
            }
            double squareRoot = Math.Sqrt(number);
            Console.WriteLine("{0:f3}", squareRoot);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}