using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct11_Task3
{
    class Program
    {
        static void Main()
        {
            var sequence = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var differenceArray = new long[sequence.Length - 1];
            for (int i = 1; i <= sequence.Length - 1; i++)
            {
                long smallerNum = 0;
                long biggerNum = 0;
                if (sequence[i - 1] >= sequence[i])
                {
                    biggerNum = sequence[i - 1];
                    smallerNum = sequence[i];
                }
                else
                {

                    smallerNum = sequence[i - 1];
                    biggerNum = sequence[i];
                }
                long difference = biggerNum - smallerNum;
                differenceArray[i - 1] = difference;
            }

            for (int j = 1; j < sequence.Length; j++)
            {
                long difference = sequence[j] - sequence[j - 1];
                if (difference % 2 == 0)
                {
                    if (j < differenceArray.Length)
                    {
                        differenceArray[j] = 0;
                    }
                    j++;
                }
            }

            long sumForPrint = differenceArray.Where(n => n % 2 == 0).Sum();
            Console.WriteLine(sumForPrint);
        }
    }
}
