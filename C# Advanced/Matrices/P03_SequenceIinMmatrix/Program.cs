using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var matrixSizeInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var matrix = new string[matrixSizeInput[0], matrixSizeInput[1]];

        for (int row = 0; row < matrixSizeInput[0]; row++)
        {
            var rowInfo = Console.ReadLine().Split(' ').ToArray();
            for (int col = 0; col < rowInfo.Length; col++)
            {
                matrix[row, col] = rowInfo[col];
            }
        }

        int maxSequence = int.MinValue;
        string currentString = string.Empty;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentString = matrix[row, col];
                int currentRowMaxSequence = 0;
                int currentColMaxSequence = 0;
                int currentRightDiagonalMaxSequence = 0;
                int currentLeftDiagonalMaxSequence = 0;

                for (int rowToCheck = row; rowToCheck < matrix.GetLength(0); rowToCheck++)
                {
                    if (matrix[rowToCheck, col] == currentString)
                    {
                        currentColMaxSequence++;
                    }

                    else
                    {
                       break;
                    }
                }

                for (int colToCheck = col; colToCheck < matrix.GetLength(1); colToCheck++)
                {
                    if (matrix[row, colToCheck] == currentString)
                    {
                        currentRowMaxSequence++;
                    }
                    else
                    {
                        break;
                    }
                }

                for (int rowDiagonal = row, colDiagonal = col;;)
                {
                    if(matrix[rowDiagonal,colDiagonal] == currentString)
                    {
                        currentRightDiagonalMaxSequence++;
                    }
                    if (rowDiagonal + 1 < matrix.GetLength(0) && colDiagonal + 1 < matrix.GetLength(1))
                    {
                        rowDiagonal++;
                        colDiagonal++;
                    }
                    else
                    {
                       break;
                    }
                }

                for (int rowDiagonal = row, colDiagonal = col; ;)
                {
                    if (matrix[rowDiagonal, colDiagonal] == currentString)
                    {
                        currentLeftDiagonalMaxSequence++;
                    }
                    if (rowDiagonal + 1 < matrix.GetLength(0) && colDiagonal - 1 >= 0)
                    {
                        rowDiagonal++;
                        colDiagonal--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentColMaxSequence > maxSequence)
                {
                    maxSequence = currentColMaxSequence;
                }

                if (currentRowMaxSequence > maxSequence)
                {
                    maxSequence = currentRowMaxSequence;
                }

                if (currentRightDiagonalMaxSequence > maxSequence)
                {
                    maxSequence = currentRightDiagonalMaxSequence;
                }

                if (currentLeftDiagonalMaxSequence > maxSequence)
                {
                    maxSequence = currentLeftDiagonalMaxSequence;
                }
            }
        }
        Console.WriteLine(maxSequence);
    }
}

