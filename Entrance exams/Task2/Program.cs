using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> primes = new List<int>();

            if (n <= 2)
            {
                primes.Add(1);
                primes.Add(2);
            }
            else
            {
                primes.Add(1);
                primes.Add(2);
                for (int i = 3; i <= n; i++)
                {
                    bool isPrime = ToTestPrimeNum(i);
                    if (isPrime)
                    {
                        primes.Add(i);
                    }
                }
            }
            
            foreach (var primenum in primes.OrderBy(p => p).ToList())
            {
                for (int i = 1; i <= primenum; i++)
                {
                    bool isPrimeForPrint = ToTestPrimeNum(i);
                    if (isPrimeForPrint)
                    {
                        Console.Write(1);
                    }
                    else
                    {
                        Console.Write(0);
                    }
                }
                Console.WriteLine();
            }

        }

      
        static bool ToTestPrimeNum(int num)
        {
            
            for (int i = 2, maxValue = (int)Math.Sqrt(num); i <= maxValue; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
