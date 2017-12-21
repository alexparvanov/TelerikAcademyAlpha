using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var boardSizes = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        int[][] firstMatrix = new int[boardSizes[0]][];
        bool[][] firstPlayerVisited = new bool[boardSizes[0]][];

        int[][] secondMatrix = new int[boardSizes[0]][];
        bool[][] secondPlayerVisited = new bool[boardSizes[0]][];


        for (int i = 0; i < boardSizes[0]; i++)
        {
            firstMatrix[i] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            firstPlayerVisited[i] = new bool[firstMatrix[i].Length];
        }

        for (int i = boardSizes[0] - 1; i >= 0; i--)
        {
            secondMatrix[i] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            secondPlayerVisited[i] = new bool[firstMatrix[i].Length];

        }

        string inputCommand = string.Empty;
        do
        {
            inputCommand = Console.ReadLine();

            if (inputCommand == "END")
            {
                break;
            }

            string[] commands = inputCommand.Split();
            string playerInfo = commands[0];
            int rowToBomb = int.Parse(commands[1]);
            int colToBomb = int.Parse(commands[2]);

            if (playerInfo == "P1")
            {
                if (firstPlayerVisited[rowToBomb][colToBomb])
                {
                    Console.WriteLine("Try again!");
                }
                else
                {
                    firstPlayerVisited[rowToBomb][colToBomb] = true;
                    string result = PutBombOnMatrix(secondMatrix, rowToBomb, colToBomb);
                    Console.WriteLine(result);
                }
            }
            else if (playerInfo == "P2")
            {
                if (secondPlayerVisited[rowToBomb][colToBomb])
                {
                    Console.WriteLine("Try again!");
                }
                else
                {
                    secondPlayerVisited[rowToBomb][colToBomb] = true;
                    string result = PutBombOnMatrix(firstMatrix, rowToBomb, colToBomb);
                    Console.WriteLine(result);
                }
            }

        } while (true);

        int firstPlayerResult = CalculatePlayerResult(firstMatrix);
        int secondPlayerResult = CalculatePlayerResult(secondMatrix);
        Console.WriteLine($"{firstPlayerResult}:{secondPlayerResult}");
    }

    static int CalculatePlayerResult(int[][] matrix)
    {
        int result = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 1)
                {
                    result++;
                }
            }
        }
        return result;
    }

    static string PutBombOnMatrix(int[][] matrix, int rowToBomb, int colToBomb)
    {
        if (matrix[rowToBomb][colToBomb] == 0)
        {
            return "Missed";
        }
        if (matrix[rowToBomb][colToBomb] == 1)
        {
            matrix[rowToBomb][colToBomb] = 0;
            return "Booom";
        }
        return String.Empty;
    }
}