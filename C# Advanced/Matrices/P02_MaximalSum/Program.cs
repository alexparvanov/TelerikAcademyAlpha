using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var matrixSizeInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var matrix = new int [matrixSizeInput[0], matrixSizeInput[1]];

        for (int row = 0; row < matrixSizeInput[0]; row++)
        {
            var rowInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int col = 0; col < rowInfo.Length; col++)
            {
                matrix[row,col] = rowInfo[col];
            }
        }

        int maxSum = int.MinValue;

        for (int i = 1; i < matrix.GetLength(0)-1; i++)
        {
            for (int j = 1; j < matrix.GetLength(1) - 1; j++)
            {
                int currentSum = matrix[i-1,j-1] + matrix[i-1,j] + matrix[i-1, j+1]
                    + matrix[i, j-1] + matrix[i,j] + matrix[i, j+1]
                    + matrix[i+1, j-1] + matrix[i+1, j] + matrix[i+1, j+1];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }
        Console.WriteLine(maxSum);
    }
}

