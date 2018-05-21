namespace task08_Portals
{
    using System;

    class Program
    {
        private static int finalMaxPower;
        private static int currentMaxPower;
        private static int[,] matrix;
        static void Main()
        {
            var initialCoordinatesInput = Console.ReadLine().Split();
            int initRow = int.Parse(initialCoordinatesInput[0]);
            int initCol = int.Parse(initialCoordinatesInput[1]);
            var labyrinthRowCol = Console.ReadLine().Split();
            var rows = int.Parse(labyrinthRowCol[0]);
            var cols = int.Parse(labyrinthRowCol[1]);
            matrix = new int[rows, cols];
            
            for (int i = 0; i < rows; i++)
            {
                var currentInput = Console.ReadLine().Split();

                for (int j = 0; j < cols; j++)
                {
                    if (int.TryParse(currentInput[j], out matrix[i, j]))
                    {
                    }
                    else
                    {
                        matrix[i, j] = -1;
                    }
                }
            }

            CalculateMaxPower(initRow, initCol);
            Console.WriteLine(finalMaxPower);
        }

        private static void CalculateMaxPower(int currentRow, int currentCol)
        {
            int currentTeleportationPower = matrix[currentRow, currentCol];
            if (currentTeleportationPower == 0)
            {
                if (currentMaxPower > finalMaxPower)
                {
                    finalMaxPower = currentMaxPower;
                }
                return;
            }

            var canGoDown = CanGo(currentRow + currentTeleportationPower, currentCol);
            var canGoUp = CanGo(currentRow - currentTeleportationPower, currentCol);
            var canGoLeft = CanGo(currentRow, currentCol - currentTeleportationPower);
            var canGoRight = CanGo(currentRow, currentCol + currentTeleportationPower);
            if (!canGoRight && !canGoDown && !canGoLeft && !canGoUp)
            {
                if (currentMaxPower > finalMaxPower)
                {
                    finalMaxPower = currentMaxPower;
                }
                return;
            }

            currentMaxPower += currentTeleportationPower;
            matrix[currentRow, currentCol] = 0;
            if (canGoRight)
            {
                CalculateMaxPower(currentRow, currentCol + currentTeleportationPower);
            }
            if (canGoLeft)
            {
                CalculateMaxPower(currentRow, currentCol - currentTeleportationPower);
            }
            if (canGoDown)
            {
                CalculateMaxPower(currentRow + currentTeleportationPower, currentCol);
            }
            if (canGoUp)
            {
                CalculateMaxPower(currentRow - currentTeleportationPower, currentCol);
            }
            
            currentMaxPower -= currentTeleportationPower;
            matrix[currentRow, currentCol] = currentTeleportationPower;
        }

        private static bool CanGo(int targetRow, int targetCol)
        {
            if (targetCol < 0 || targetRow < 0 || targetCol >= matrix.GetLength(1) || targetRow >= matrix.GetLength(0) || matrix[targetRow, targetCol] == -1)
            {
                return false;
            }
            return true;
        }
    }
}