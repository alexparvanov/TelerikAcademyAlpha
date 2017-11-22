using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct_11_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int lineNum = int.Parse(Console.ReadLine());

            var nums = new long[3];
            nums[0] = num1;
            nums[1] = num2;
            nums[2] = num3;

            Console.WriteLine(num1);
            Console.Write(num2);
            Console.Write(" ");
            Console.WriteLine(num3);

            if (lineNum > 2)
            {
                for (int i = 3; i <= lineNum; i++)
                {
                    long currentNumMinus3 = nums[nums.Length - 3];
                    long currentNumMinus2 = nums[nums.Length - 2];
                    long currentNumMinus1 = nums[nums.Length - 1];

                    long sumOfFirstNum = currentNumMinus1 + currentNumMinus2 + currentNumMinus3;
                    nums = new long[i];
                    nums[0] = sumOfFirstNum;
                    long sumOfSecondNum = sumOfFirstNum + currentNumMinus2 + currentNumMinus1;
                    nums[1] = sumOfSecondNum;
                    long sumOfThirdNum = sumOfFirstNum + sumOfSecondNum + currentNumMinus1;
                    nums[2] = sumOfThirdNum;

                    if (i > 3)
                    {
                        for (int j = 4; j <= i; j++)
                        {
                            long numToAdd = nums[j - 2] + nums[j - 3] + nums[j - 4];
                            nums[j - 1] = numToAdd;
                        }
                    }
                    Console.WriteLine(string.Join(" ", nums));
                }
            }
        }
    }
}