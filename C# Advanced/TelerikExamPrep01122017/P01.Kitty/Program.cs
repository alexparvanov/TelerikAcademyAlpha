using System;
using System.Linq;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        char[] positions = Console.ReadLine().ToCharArray();
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int jumps = 0;
        int soulsCollected = 0;
        int foodCollected = 0;
        int deadlocks = 0;
        int currentPosition = 0;

        char initialChar = positions[currentPosition];

        switch (initialChar)
        {
            case '@':
                soulsCollected++;
                positions[currentPosition] = 'e';
                break;
            case '*':
                foodCollected++;
                positions[currentPosition] = 'e';
                break;
            case 'x':
                Console.WriteLine("You are deadlocked, you greedy kitty!" + Environment.NewLine +
                $"Jumps before deadlock: {jumps}");
                return;
        }



        for (int i = 0; i < numbers.Length; i++)
        {
            jumps++;
            int move = numbers[i];

            if (move >= 0)
            {
                currentPosition += move;
                while (currentPosition > positions.Length - 1)
                {
                    currentPosition -= positions.Length;
                }
            }

            if (move < 0)
            {
                currentPosition += move;
                while (currentPosition < 0)
                {
                    currentPosition += positions.Length;
                }
            }
      
            char currentChar = positions[currentPosition];
            switch (currentChar)
            {
                case 'e':
                    break;
                case '@':
                    soulsCollected++;
                    positions[currentPosition] = 'e';
                    break;
                case '*':
                    foodCollected++;
                    positions[currentPosition] = 'e';
                    break;
                case 'x':
                    if (currentPosition % 2 == 0)
                    {
                        if (soulsCollected > 0)
                        {
                            soulsCollected--;
                            deadlocks++;
                            positions[currentPosition] = '@';
                        }
                        else
                        {
                            Console.WriteLine("You are deadlocked, you greedy kitty!" + Environment.NewLine +
                                              $"Jumps before deadlock: {jumps}");
                            return;
                        }
                    }
                    else
                    {
                        if (foodCollected > 0)
                        {
                            foodCollected--;
                            deadlocks++;
                            positions[currentPosition] = '*';
                        }
                        else
                        {
                            Console.WriteLine("You are deadlocked, you greedy kitty!" + Environment.NewLine +
                                              $"Jumps before deadlock: {jumps}");
                            return;
                        }
                    }
                    break;

            }
        }
        Console.WriteLine($"Coder souls collected: {soulsCollected}");
        Console.WriteLine($"Food collected: {foodCollected}");
        Console.WriteLine($"Deadlocks: {deadlocks}");
    }
}