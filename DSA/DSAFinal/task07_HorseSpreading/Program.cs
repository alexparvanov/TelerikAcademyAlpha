using System;
using System.Collections.Generic;
using System.Linq;

namespace task07_HorseSpreading
{

    class HorsePosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }

    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            int printCol = cols / 2;

            if (printCol == startCol)
            {
                cols = 5;
                startCol = cols / 2;
                printCol = startCol;
            }
            else if (printCol < startCol)
            {
                cols = 5 + (startCol - printCol);
                startCol = cols - 3;
                printCol = 2;
            }
            else
            {
                cols = 5 + (printCol - startCol);
                startCol =  2;
                printCol = cols - 3;
            }
            var matrix = new int[rows, cols];
            matrix[startRow, startCol] = 1;

            var validPositions = new Queue<HorsePosition>();
            var firstPosition = new HorsePosition
            {
                Row = startRow,
                Col = startCol
            };
            validPositions.Enqueue(firstPosition);

            while (validPositions.Any())
            {
                var currentPosition = validPositions.Dequeue();

                var currentRow = currentPosition.Row;
                var currentCol = currentPosition.Col;

                var currentValue = matrix[currentRow, currentCol];

                if (currentRow - 2 > -1 && currentCol + 1 < cols && matrix[currentRow - 2, currentCol + 1] == 0)
                {
                    var nextValidRow = currentRow - 2;
                    var nextValidCol = currentCol + 1;

                    var nextValidPosition = new HorsePosition
                    {
                        Row = nextValidRow,
                        Col = nextValidCol
                    };
                    validPositions.Enqueue(nextValidPosition);
                    matrix[nextValidRow, nextValidCol] = currentValue + 1;
                }

                if (currentRow - 1 > -1 && currentCol + 2 < cols && matrix[currentRow - 1, currentCol + 2] == 0)
                {
                    var nextValidRow = currentRow - 1;
                    var nextValidCol = currentCol + 2;

                    var nextValidPosition = new HorsePosition
                    {
                        Row = nextValidRow,
                        Col = nextValidCol
                    };
                    validPositions.Enqueue(nextValidPosition);
                    matrix[nextValidRow, nextValidCol] = currentValue + 1;
                }

                if (currentRow + 1 < rows && currentCol + 2 < cols && matrix[currentRow + 1, currentCol + 2] == 0)
                {
                    var nextValidRow = currentRow + 1;
                    var nextValidCol = currentCol + 2;
                    var nextValidPosition = new HorsePosition
                    {
                        Row = nextValidRow,
                        Col = nextValidCol
                    };
                    validPositions.Enqueue(nextValidPosition);
                    matrix[nextValidRow, nextValidCol] = currentValue + 1;
                }

                if (currentRow + 2 < rows && currentCol + 1 < cols && matrix[currentRow + 2, currentCol + 1] == 0)
                {
                    var nextValidRow = currentRow + 2;
                    var nextValidCol = currentCol + 1;

                    var nextValidPosition = new HorsePosition
                    {
                        Row = nextValidRow,
                        Col = nextValidCol
                    };
                    validPositions.Enqueue(nextValidPosition);
                    matrix[nextValidRow, nextValidCol] = currentValue + 1;
                }

                if (currentRow + 2 < rows && currentCol - 1 > -1 && matrix[currentRow + 2, currentCol - 1] == 0)
                {
                    var nextValidRow = currentRow + 2;
                    var nextValidCol = currentCol - 1;

                    var nextValidPosition = new HorsePosition
                    {
                        Row = nextValidRow,
                        Col = nextValidCol
                    };
                    validPositions.Enqueue(nextValidPosition);
                    matrix[nextValidRow, nextValidCol] = currentValue + 1;
                }

                if (currentRow + 1 < rows && currentCol - 2 > -1 && matrix[currentRow + 1, currentCol - 2] == 0)
                {
                    var nextValidRow = currentRow + 1;
                    var nextValidCol = currentCol - 2;

                    var nextValidPosition = new HorsePosition
                    {
                        Row = nextValidRow,
                        Col = nextValidCol
                    };
                    validPositions.Enqueue(nextValidPosition);
                    matrix[nextValidRow, nextValidCol] = currentValue + 1;
                }

                if (currentRow - 1 > -1 && currentCol - 2 > -1 && matrix[currentRow - 1, currentCol - 2] == 0)
                {
                    var nextValidRow = currentRow - 1;
                    var nextValidCol = currentCol - 2;

                    var nextValidPosition = new HorsePosition
                    {
                        Row = nextValidRow,
                        Col = nextValidCol
                    };
                    validPositions.Enqueue(nextValidPosition);
                    matrix[nextValidRow, nextValidCol] = currentValue + 1;
                }

                if (currentRow - 2 > -1 && currentCol - 1 > -1 && matrix[currentRow - 2, currentCol - 1] == 0)
                {
                    var nextValidRow = currentRow - 2;
                    var nextValidCol = currentCol - 1;

                    var nextValidPosition = new HorsePosition
                    {
                        Row = nextValidRow,
                        Col = nextValidCol
                    };
                    validPositions.Enqueue(nextValidPosition);
                    matrix[nextValidRow, nextValidCol] = currentValue + 1;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(matrix[i, printCol]);
            }
        }
    }
}
