using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        var sb = new StringBuilder();

        do
        {
            int startIndex = input.IndexOf("<upcase>,");
            int endIndex = input.IndexOf("</upcase>");

            if (startIndex == -1)
            {
                sb.Append(input);
                break;
            }

            sb.Append(input.Substring(0, startIndex));
            sb.Append(input.Substring(startIndex + 8, endIndex - (startIndex + 8)).ToUpper());
            input = input.Substring(endIndex + 9);
        } while (true);
        Console.WriteLine(sb.ToString());
    }
}