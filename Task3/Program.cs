using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var carrots = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            var directionsToTry = int.Parse(Console.ReadLine());

            int maximumEaten = int.MinValue;
            var eatenIndex = new List<int>();
            int totalEaten = 0;
            bool isCurrentCycleEnded = false;
            bool firstIndex = true;
            int currentIndex = 0;
            for (int i = 0; i < directionsToTry; i++)
            {
                var directions = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int k = 0; k < directionsToTry; k++)
                {
                    for (int j = 0; j < directions.Length; j++)
                    {
                        if (firstIndex)
                        {
                            totalEaten += carrots[0];
                            eatenIndex.Add(0);
                            firstIndex = false;
                            j--;
                        }
                        else
                        {
                            currentIndex += directions[j];

                            if (currentIndex < 0 || currentIndex >= carrots.Length || eatenIndex.Contains(currentIndex))
                            {
                                if (totalEaten >= maximumEaten)
                                {
                                    maximumEaten = totalEaten;
                                }
                                isCurrentCycleEnded = true;
                                break;
                            }
                            eatenIndex.Add(currentIndex);

                            totalEaten += carrots[currentIndex];
                        }
                    }
                    if (isCurrentCycleEnded)
                    {
                        break;
                    }
                }
                isCurrentCycleEnded = false;
                firstIndex = true;
                if (totalEaten >= maximumEaten)
                {
                    maximumEaten = totalEaten;
                }
                eatenIndex.Clear();
                totalEaten = 0;
                currentIndex = 0;
            }
            
            Console.WriteLine(maximumEaten);
        }
    }
}
