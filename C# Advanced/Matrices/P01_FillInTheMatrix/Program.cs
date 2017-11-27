using System;

namespace P01_FillInTheMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = int.Parse(Console.ReadLine());

            char arrayType = char.Parse(Console.ReadLine());

            int[,] array = new int[arraySize, arraySize];

            if (arrayType == 'a')
            {
                for (int row = 0; row < array.GetLength(0); row++)
                {
                    for (int col = 0; col < array.GetLength(1); col++)
                    {
                        array[row, col] = row + 1 + arraySize * col;
                    }
                }
                PrintArray(array, arraySize);
            }

            else if (arrayType == 'b')
            {
                for (int row = 0; row < array.GetLength(1); row++)
                {
                    for (int col = 0; col < array.GetLength(1); col++)
                    {
                        if (col % 2 != 0)
                        {
                            array[row, col] = arraySize * (col + 1) - row;
                        }
                        else
                        {
                            array[row, col] = row + 1 + arraySize * col;
                        }
                    }
                }
                PrintArray(array, arraySize);
            }

            else if (arrayType == 'c')
            {
                int num = 1;
                for (int row = arraySize - 1, col = 0; col < arraySize;)
                {
                    array[row, col] = num;
                    num++;

                    for (int startR = row, startC = col; ;)
                    {
                        if (startR + 1 < arraySize && startC + 1 < arraySize)
                        {
                            startR++;
                            startC++;
                            array[startR, startC] = num;
                            num++;
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
                PrintArray(array, arraySize);
            }

            else if (arrayType == 'd')
            {
                char dir = 'd';
                int num = 1;
                for (int col = 0, row = 0; num <= arraySize * arraySize;)
                {
                    array[row, col] = num++;

                    switch (dir)
                    {
                        case 'd':
                            if (row + 1 == arraySize || array[row + 1, col] != 0)
                            {
                                dir = 'r';
                                col++;
                            }
                            else
                            {
                                row++;
                            }
                            break;
                        case 'r':
                            if (col + 1 == arraySize || array[row, col + 1] != 0)
                            {
                                dir = 'u';
                                row--;
                            }
                            else
                            {
                                col++;
                            }
                            break;
                        case 'u':
                            if ( row - 1 < 0 || array[row - 1, col] != 0)
                            {
                                dir = 'l';
                                col--;
                            }
                            else
                            {
                                row--;
                            }
                            break;
                        case 'l':
                            if (col - 1 < 0 || array[row, col - 1] != 0)
                            {
                                dir = 'd';
                                row++;
                            }
                            else
                            {
                                col--;
                            }
                            break;
                    }
                }
                PrintArray(array, arraySize);
            }
        }

        private static void PrintArray(int[,] array, int arraySize)
        {
            for (int row = 0; row < arraySize; row++)
            {
                for (int col = 0; col < arraySize; col++)
                {
                    Console.Write(array[row, col]);
                    if (col < arraySize - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
