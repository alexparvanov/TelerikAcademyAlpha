using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int counter = -1;
        int numToFill;
        int sumCollected = 0;
        var matrixSize = Console.ReadLine().Split().ToArray();

        var matrix = new int[int.Parse(matrixSize[0]), int.Parse(matrixSize[1])];

        for (int row = matrix.GetLength(0) - 1, col = 0; col < matrix.GetLength(1);)
        {
            counter++;
            numToFill = counter * 3;
            matrix[row, col] = numToFill;

            for (int rowToFill = row, colToFill = col; ;)
            {

                if (rowToFill + 1 < matrix.GetLength(0) && colToFill + 1 < matrix.GetLength(1))
                {
                    rowToFill++;
                    colToFill++;
                    matrix[rowToFill, colToFill] = numToFill;
                }
                else
                {
                    break;
                }
            }
            if (row != 0)
            {
                row--;
            }
            else
            {
                col++;
            }
        }

        int commandsCount = int.Parse(Console.ReadLine());

        int currentRow = matrix.GetLength(0) - 1;
        int currentCol = 0;

        for (int j = 0; j < commandsCount; j++)
        {
            string[] commandInput = Console.ReadLine().Split().ToArray();
            string direction = commandInput[0];
            int directionCount = int.Parse(commandInput[1]);

            switch (direction)
            {
                case "UR":
                case "RU":
                    for (int i = 0; i < directionCount; i++)
                    {
                        if (matrix[currentRow, currentCol] != -1)
                        {
                            sumCollected += matrix[currentRow, currentCol];
                            matrix[currentRow, currentCol] = -1;
                        }
                        if (currentRow - 1 >= 0 && currentCol + 1 < matrix.GetLength(1))
                        {
                            if (i < directionCount - 1)
                            {
                                currentRow--;
                                currentCol++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case "LU":
                case "UL":
                    for (int i = 0; i < directionCount; i++)
                    {
                        if (matrix[currentRow, currentCol] != -1)
                        {
                            sumCollected += matrix[currentRow, currentCol];
                            matrix[currentRow, currentCol] = -1;
                        }
                        if (currentRow - 1 >= 0 && currentCol - 1 >= 0)
                        {
                            if (i < directionCount - 1)
                            {
                                currentRow--;
                                currentCol--;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case "DL":
                case "LD":
                    for (int i = 0; i < directionCount; i++)
                    {
                        if (matrix[currentRow, currentCol] != -1)
                        {
                            sumCollected += matrix[currentRow, currentCol];
                            matrix[currentRow, currentCol] = -1;
                        }
                        if (currentRow + 1 < matrix.GetLength(0) && currentCol - 1 >= 0)
                        {
                            if (i < directionCount - 1)
                            {
                                currentRow++;
                                currentCol--;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case "DR":
                case "RD":
                    for (int i = 0; i < directionCount; i++)
                    {
                        if (matrix[currentRow, currentCol] != -1)
                        {
                            sumCollected += matrix[currentRow, currentCol];
                            matrix[currentRow, currentCol] = -1;
                        }
                        if (currentRow + 1 < matrix.GetLength(0) && currentCol + 1 < matrix.GetLength(1))
                        {
                            if (i < directionCount - 1)
                            {
                                currentRow++;
                                currentCol++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
            }
        }
        Console.WriteLine(sumCollected);
    }
}