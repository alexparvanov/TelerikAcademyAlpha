using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        bool isNegative = false;
        if (input[0] == '-')
        {
            isNegative = true;
        }
        BigInteger result = 0;

        if (isNegative)
        {
            int[] nums = new int[input.Length - 1];

            for (int i = 1; i < input.Length; i++)
            {
                nums[i - 1] = int.Parse(input[i].ToString());
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];
                int currentIndex = nums.Length - i;
                if (currentIndex % 2 == 0)
                {
                    result += currentNum * currentNum * currentIndex;
                }
                else
                {
                    result += currentNum * currentIndex * currentIndex;
                }
            }
        }

        else
        {
            int[] nums = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                nums[i] = int.Parse(input[i].ToString());
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];
                int currentIndex = nums.Length - i;
                if (currentIndex % 2 == 0)
                {
                    result += currentNum * currentNum * currentIndex;
                }
                else
                {
                    result += currentNum * currentIndex * currentIndex;
                }
            }

        }
        int resultLength = (int)(result % 10);
        if (resultLength == 0)
        {
            Console.WriteLine(result);
            Console.WriteLine("Big Vik wins again!");
        }

        else
        {
            Console.WriteLine(result);

            char[] resultChars = new char[resultLength];

            int initialChar = (int)(result % 26) + 1;

            for (int i = 0; i < resultChars.Length; i++)
            {
                resultChars[i] = (char)(initialChar + 64);
                if (initialChar + 64 == 90)
                {
                    initialChar = 1;
                }
                else
                {
                    initialChar++;
                }
            }

            Console.WriteLine(string.Join("", resultChars));
        }
    }
}