using System;
using System.Linq;

class Program
{
    static int currentIndex;
    static void Main()
    {
        currentIndex = int.Parse(Console.ReadLine());
        int[] array = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
        long forwardSum = 0;
        long backwardSum = 0;

        string inputCommands = String.Empty;

        do
        {
            inputCommands = Console.ReadLine();

            if (inputCommands == "exit")
            {
                break;
            }

            string[] commands = inputCommands.Split();

            int steps = int.Parse(commands[0]);

            string direction = commands[1];
            int stepSize = int.Parse(commands[2]);
            if (direction == "forward")
            {
                forwardSum += CalculateForwardSum(array, steps, stepSize);
            }
            else if (direction == "backwards")
            {
               backwardSum += CalculateBackwardsSum(array, steps, stepSize);
            }
        } while (true);

        Console.WriteLine($"Forward: {forwardSum}");
        Console.WriteLine($"Backwards: {backwardSum}");
    }

    static long CalculateBackwardsSum(int[] array, int steps, int stepSize)
    {
        int currentSum = 0;

        for (int i = 0; i < steps; i++)
        {
            if (currentIndex - stepSize >= 0)
            {
                currentIndex -= stepSize;
                currentSum += array[currentIndex];
            }
            else
            {
                currentIndex -= stepSize;
                while (currentIndex < 0)
                {
                    currentIndex += array.Length;
                }

                currentSum += array[currentIndex];
            }
        }
        return currentSum;
    }

    static long CalculateForwardSum(int[] array, int steps, int stepSize)
    {
        int currentSum = 0;

        for (int i = 0; i < steps; i++)
        {
            if (currentIndex + stepSize < array.Length)
            {
                currentIndex += stepSize;
                currentSum += array[currentIndex];
            }
            else
            {
                currentIndex += stepSize;
                while (currentIndex > array.Length - 1)
                {
                    currentIndex -= array.Length;
                }
                
                currentSum += array[currentIndex];
            }
        }
        return currentSum;
    }
}