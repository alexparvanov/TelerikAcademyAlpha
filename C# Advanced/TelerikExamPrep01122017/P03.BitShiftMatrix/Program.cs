using System;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        int moves = int.Parse(Console.ReadLine());
        decimal[] codes = new decimal[moves];
        codes = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

        int counter = -1;

        BigInteger collectedSum = 0;

        int coeff = Math.Max(rows, cols);
        BigInteger[,] matrix = new BigInteger[rows, cols];

        BigInteger num = (BigInteger)Math.Pow(2, counter);

        for (int row = rows - 1, col = 0; col < cols;)
        {
            counter++;
            num = (BigInteger)Math.Pow(2, counter);
            matrix[row, col] = num;
            for (int rowToFill = row, colToFill = col; ;)
            {

                if (rowToFill + 1 < rows && colToFill + 1 < cols)
                {
                    rowToFill++;
                    colToFill++;
                    matrix[rowToFill, colToFill] = num;
                }
                else
                {
                    break;
                }
            }
            if (row > 0)
            {
                row--;
            }
            else
            {
                col++;
            }
        }
        
        int currentRow = rows - 1;
        int currentCol = 0;

        for (int i = 0; i < codes.Length; i++)
        {
            decimal currentCode = codes[i];

            int destinationRow = (int)currentCode / coeff;
            int destinationCol = (int)currentCode % coeff;

            if (currentCol < destinationCol)
            {
                for (int colMoves = currentCol; colMoves <= destinationCol; colMoves++)
                {
                    collectedSum += matrix[currentRow, colMoves];
                    matrix[currentRow, colMoves] = 0;
                }
                currentCol = destinationCol;
            }
            else if (currentCol > destinationCol)
            {
                for (int colMoves = currentCol; colMoves >= destinationCol; colMoves--)
                {
                    collectedSum += matrix[currentRow, colMoves];
                    matrix[currentRow, colMoves] = 0;
                }
                currentCol = destinationCol;
            }
            else if(currentCol == destinationCol)
            {
                collectedSum += matrix[currentRow, currentCol];
                matrix[currentRow, currentCol] = 0;
            }

            if (currentRow > destinationRow)
            {
                for (int rowMoves = currentRow; rowMoves >= destinationRow; rowMoves--)
                {
                    collectedSum += matrix[rowMoves, currentCol];
                    matrix[rowMoves, currentCol] = 0;
                }
                currentRow = destinationRow;
            }
            else if (currentRow < destinationRow)
            {
                for (int rowMoves = currentRow; rowMoves <= destinationRow; rowMoves++)
                {
                    collectedSum += matrix[rowMoves, currentCol];
                    matrix[rowMoves, currentCol] = 0;
                }
                currentRow = destinationRow;
            }
            else if (currentRow == destinationRow)
            {
                collectedSum += matrix[currentRow, currentCol];
                matrix[currentRow, currentCol] = 0;
            }
        }
        Console.WriteLine(collectedSum);
    }
}