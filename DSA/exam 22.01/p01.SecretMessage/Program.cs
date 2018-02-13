using System;
using System.Text;

namespace p01.SecretMessage
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var replacementString = new StringBuilder();

            int openingIndex = 0;

            int closingIndex = 0;
            do
            {
                if (!input.Contains("{"))
                {
                    break;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '{')
                    {
                        openingIndex = i;
                    }
                    else if (input[i] == '}')
                    {
                        closingIndex = i;
                        break;
                    }
                }

                string letters = input.Substring(openingIndex + 1, closingIndex - openingIndex - 1);
                int digitsCount = 1;
                do
                {
                    if (openingIndex - digitsCount - 1 < 0)
                    {
                        break;
                    }
                    if (!char.IsDigit(input[openingIndex - digitsCount - 1]))
                    {
                        break;
                    }
                    digitsCount++;

                } while (true);

                int repeatCount = int.Parse(input.Substring(openingIndex - digitsCount, digitsCount));

                for (int i = 0; i < repeatCount; i++)
                {
                    replacementString.Append(letters);
                }

                string stringToReplace = input.Substring(openingIndex - digitsCount, digitsCount + 2 + letters.Length);
                input = input.Replace(stringToReplace, replacementString.ToString());
                replacementString.Clear();
            } while (true);

            Console.WriteLine(input);
        }
    }
}