using System;
using System.Collections.Generic;
using System.Linq;

namespace JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var jedis = Console.ReadLine().Split().ToList();
            List<string> masters = new List<string>();
            List<string> knights = new List<string>();
            List<string> padawans = new List<string>();

            foreach (string jedi in jedis)
            {
                char jediType = jedi[0];
                switch (jediType)
                {
                    case 'M':
                        masters.Add(jedi);
                        break;
                    case 'K':
                        knights.Add(jedi);
                        break;
                    case 'P':
                        padawans.Add(jedi);
                        break;
                }
            }

            List<string> finalJedis = new List<string>();
            finalJedis.AddRange(masters);
            finalJedis.AddRange(knights);
            finalJedis.AddRange(padawans);

            Console.WriteLine(string.Join(" ", finalJedis));
        }
    }
}
