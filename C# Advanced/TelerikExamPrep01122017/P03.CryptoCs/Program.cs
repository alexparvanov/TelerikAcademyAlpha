using System;
using System.Linq;
using System.Runtime.CompilerServices;

class Program
{
    private static int rabbitScore;
    private static int porcupineScore;
    static void Main()
    {
        int baseColumnCount = int.Parse(Console.ReadLine());
        int totalRowsCount = int.Parse(Console.ReadLine());
        int columnCounter = 1;
        int[] porcupineCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] rabbitCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();


        int[][] matrix = new int[totalRowsCount][];

        for (int i = 0; i < totalRowsCount / 2; i++)
        {
            matrix[i] = new int[baseColumnCount * columnCounter];
            columnCounter++;
        }

        for (int i = totalRowsCount / 2; i < totalRowsCount; i++)
        {
            columnCounter--;
            matrix[i] = new int[baseColumnCount * columnCounter];
        }


        for (int i = 0; i < totalRowsCount; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] = (i + 1) * (j + 1);
            }
        }


        rabbitScore = matrix[rabbitCoordinates[0]][rabbitCoordinates[1]];
        porcupineScore = matrix[porcupineCoordinates[0]][porcupineCoordinates[1]];
        matrix[rabbitCoordinates[0]][rabbitCoordinates[1]] = 0;
        matrix[porcupineCoordinates[0]][porcupineCoordinates[1]] = 0;

        string commands = String.Empty;

        while (true)
        {
            commands = Console.ReadLine();
            if (commands == "END")
            {
                break;
            }

            var tokens = commands.Split();

            string currentAnimal = tokens[0];
            string direction = tokens[1];

            int steps = int.Parse(tokens[2]);

            if (currentAnimal == "R")
            {
                MoveRabbitToDirectionWithSteps(direction, steps, matrix, rabbitCoordinates, porcupineCoordinates);
            }
            else if (currentAnimal == "P")
            {
                MovePorcupineToDirectionWithSteps(direction, steps, matrix, rabbitCoordinates, porcupineCoordinates);

            }
        }
        if (rabbitScore > porcupineScore)
        {
            Console.WriteLine("The rabbit WON with {0} points. The porcupine scored {1} points only.", rabbitScore, porcupineScore);
        }
        else if (rabbitScore < porcupineScore)
        {
            Console.WriteLine("The porcupine destroyed the rabbit with {0} points. The rabbit must work harder. He scored {1} points only.", porcupineScore, rabbitScore);
        }
        else
        {
            Console.WriteLine("Both units scored {0} points. Maybe we should play again?", rabbitScore);
        }
    }

    static void MovePorcupineToDirectionWithSteps(string direction, int steps, int[][] matrix, int[] rabbitCoordinates, int[] porcupineCoordinates)
    {
        int currentPorcupineRowIndex = porcupineCoordinates[0];
        int currentPorcupineColIndex = porcupineCoordinates[1];
        int currentRowLength = matrix[currentPorcupineRowIndex].Length;
        switch (direction)
        {
            case "R":

                for (int i = 0; i < steps; i++)
                {
                    if (currentPorcupineColIndex + 1 > currentRowLength - 1)
                    {
                        currentPorcupineColIndex = currentPorcupineColIndex + 1 - currentRowLength;
                    }

                    else
                    {
                        currentPorcupineColIndex++;
                    }

                    porcupineCoordinates[1] = currentPorcupineColIndex;

                    if (porcupineCoordinates[0] == rabbitCoordinates[0] && porcupineCoordinates[1] == rabbitCoordinates[1])
                    {
                        currentPorcupineColIndex--;
                    }
                    if (currentPorcupineColIndex < 0)
                    {
                        currentPorcupineColIndex = currentRowLength - 1;
                        porcupineCoordinates[1] = currentPorcupineColIndex;
                    }
                    porcupineCoordinates[0] = currentPorcupineRowIndex;
                    porcupineCoordinates[1] = currentPorcupineColIndex;
                    porcupineScore += matrix[porcupineCoordinates[0]][porcupineCoordinates[1]];
                    matrix[porcupineCoordinates[0]][porcupineCoordinates[1]] = 0;
                }
                break;

            case "L":
                for (int i = 0; i < steps; i++)
                {
                    if (currentPorcupineColIndex - 1 < 0)
                    {
                        currentPorcupineColIndex = currentPorcupineColIndex - 1 + currentRowLength;
                    }

                    else
                    {
                        currentPorcupineColIndex--;
                    }

                    porcupineCoordinates[1] = currentPorcupineColIndex;

                    if (porcupineCoordinates[0] == rabbitCoordinates[0] && porcupineCoordinates[1] == rabbitCoordinates[1])
                    {
                        currentPorcupineColIndex++;
                    }
                    if (currentPorcupineColIndex > currentRowLength - 1)
                    {
                        currentPorcupineColIndex = 0;
                        porcupineCoordinates[1] = currentPorcupineColIndex;
                    }
                    porcupineCoordinates[0] = currentPorcupineRowIndex;
                    porcupineCoordinates[1] = currentPorcupineColIndex;
                    porcupineScore += matrix[porcupineCoordinates[0]][porcupineCoordinates[1]];
                    matrix[porcupineCoordinates[0]][porcupineCoordinates[1]] = 0;

                }
                break;

            case "B":
                for (int i = 0; i < steps; i++)
                {
                    while (true)
                    {
                        if (currentPorcupineRowIndex + 1 < matrix.GetLength(0))
                        {
                            currentPorcupineRowIndex++;
                        }
                        else
                        {
                            currentPorcupineRowIndex = 0;
                        }

                        if (currentPorcupineColIndex < matrix[currentPorcupineRowIndex].Length)
                        {
                            break;
                        }
                    }

                    porcupineCoordinates[0] = currentPorcupineRowIndex;

                    if (porcupineCoordinates[0] == rabbitCoordinates[0] && porcupineCoordinates[1] == rabbitCoordinates[1])
                    {
                        while (true)
                        {
                            if (currentPorcupineRowIndex - 1 >= 0)
                            {
                                currentPorcupineRowIndex--;
                                if (currentPorcupineColIndex < matrix[currentPorcupineRowIndex].Length)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                currentPorcupineRowIndex = matrix.GetLength(0) - 1;
                                if (currentPorcupineColIndex < matrix[currentPorcupineRowIndex].Length)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    porcupineCoordinates[0] = currentPorcupineRowIndex;
                    porcupineCoordinates[1] = currentPorcupineColIndex;
                    porcupineScore += matrix[porcupineCoordinates[0]][porcupineCoordinates[1]];
                    matrix[porcupineCoordinates[0]][porcupineCoordinates[1]] = 0;
                }
                break;
            case "T":
                for (int i = 0; i < steps; i++)
                {
                    while (true)
                    {
                        if (currentPorcupineRowIndex - 1 >= 0)
                        {
                            currentPorcupineRowIndex--;
                        }
                        else
                        {
                            currentPorcupineRowIndex = matrix.GetLength(0) - 1;
                        }

                        if (currentPorcupineColIndex < matrix[currentPorcupineRowIndex].Length)
                        {
                            break;
                        }
                    }

                    porcupineCoordinates[0] = currentPorcupineRowIndex;

                    if (porcupineCoordinates[0] == rabbitCoordinates[0] && porcupineCoordinates[1] == rabbitCoordinates[1])
                    {
                        while (true)
                        {
                            if (currentPorcupineRowIndex + 1 < matrix.GetLength(0))
                            {
                                currentPorcupineRowIndex++;
                                if (currentPorcupineColIndex < matrix[currentPorcupineRowIndex].Length)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                currentPorcupineRowIndex = 0;
                                if (currentPorcupineColIndex < matrix[currentPorcupineRowIndex].Length)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    //porcupineCoordinates[0] = currentPorcupineRowIndex;
                    //porcupineCoordinates[1] = currentPorcupineColIndex;
                    porcupineScore += matrix[porcupineCoordinates[0]][porcupineCoordinates[1]];
                    matrix[porcupineCoordinates[0]][porcupineCoordinates[1]] = 0;
                }
                break;
        }
        
    }

    static void MoveRabbitToDirectionWithSteps(string direction, int steps, int[][] matrix, int[] rabbitCoordinates, int[] porcupineCoordinates)
    {
        int currentRabbitRowIndex = rabbitCoordinates[0];
        int currentRabbitColIndex = rabbitCoordinates[1];
        int currentRowLength = matrix[currentRabbitRowIndex].Length;
        int stepsRemaining = steps;

        switch (direction)
        {
            case "R":

                if (currentRabbitColIndex + steps > currentRowLength - 1)
                {
                    currentRabbitColIndex = currentRabbitColIndex + steps - currentRowLength;
                }

                else
                {
                    currentRabbitColIndex += steps;
                }

                rabbitCoordinates[1] = currentRabbitColIndex;

                if (rabbitCoordinates[0] == porcupineCoordinates[0] && rabbitCoordinates[1] == porcupineCoordinates[1])
                {
                    currentRabbitColIndex--;
                }
                if (currentRabbitColIndex < 0)
                {
                    currentRabbitColIndex = currentRowLength - 1;
                    rabbitCoordinates[1] = currentRabbitColIndex;
                }

                break;
            case "L":

                if (currentRabbitColIndex - steps < 0)
                {
                    currentRabbitColIndex = currentRabbitColIndex - steps + currentRowLength;
                }

                else
                {
                    currentRabbitColIndex -= steps;
                }

                rabbitCoordinates[1] = currentRabbitColIndex;

                if (rabbitCoordinates[0] == porcupineCoordinates[0] && rabbitCoordinates[1] == porcupineCoordinates[1])
                {
                    currentRabbitColIndex++;
                }
                if (currentRabbitColIndex > currentRowLength - 1)
                {
                    currentRabbitColIndex = 0;
                    rabbitCoordinates[1] = currentRabbitColIndex;
                }

                break;
            case "B":

                while (stepsRemaining > 0)
                {
                    if (currentRabbitRowIndex + 1 < matrix.GetLength(0))
                    {
                        currentRabbitRowIndex++;
                    }
                    else
                    {
                        currentRabbitRowIndex = 0;
                    }

                    if (currentRabbitColIndex < matrix[currentRabbitRowIndex].Length)
                    {
                        stepsRemaining--;
                    }
                }

                rabbitCoordinates[0] = currentRabbitRowIndex;

                if (rabbitCoordinates[0] == porcupineCoordinates[0] && rabbitCoordinates[1] == porcupineCoordinates[1])
                {
                    while (true)
                    {
                        if (currentRabbitRowIndex - 1 >= 0)
                        {
                            currentRabbitRowIndex--;
                            if (currentRabbitColIndex < matrix[currentRabbitRowIndex].Length)
                            {
                                break;
                            }
                        }
                        else
                        {
                            currentRabbitRowIndex = matrix.GetLength(0) - 1;
                            if (currentRabbitColIndex < matrix[currentRabbitRowIndex].Length)
                            {
                                break;
                            }
                        }
                    }
                }

                break;
            case "T":

                while (stepsRemaining > 0)
                {
                    if (currentRabbitRowIndex - 1 >= 0)
                    {
                        currentRabbitRowIndex--;
                    }
                    else
                    {
                        currentRabbitRowIndex = matrix.GetLength(0) - 1;
                    }

                    if (currentRabbitColIndex < matrix[currentRabbitRowIndex].Length)
                    {
                        stepsRemaining--;
                    }
                }

                rabbitCoordinates[0] = currentRabbitRowIndex;

                if (rabbitCoordinates[0] == porcupineCoordinates[0] && rabbitCoordinates[1] == porcupineCoordinates[1])
                {
                    while (true)
                    {
                        if (currentRabbitRowIndex + 1 < matrix.GetLength(0))
                        {
                            currentRabbitRowIndex++;
                            if (currentRabbitColIndex < matrix[currentRabbitRowIndex].Length)
                            {
                                break;
                            }
                        }
                        else
                        {
                            currentRabbitRowIndex = 0;
                            if (currentRabbitColIndex < matrix[currentRabbitRowIndex].Length)
                            {
                                break;
                            }
                        }
                    }
                }

                break;
        }
        //rabbitCoordinates[0] = currentRabbitRowIndex;
        //rabbitCoordinates[1] = currentRabbitColIndex;
        rabbitScore += matrix[rabbitCoordinates[0]][rabbitCoordinates[1]];
        matrix[rabbitCoordinates[0]][rabbitCoordinates[1]] = 0;
    }
}