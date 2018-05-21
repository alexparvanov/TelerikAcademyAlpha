using System;

namespace task04_Passwords
{
    class Program
    {
        private static bool combinationIsFound;
        private static int currentCombinationCount;
        private static int combinationNumberToShow;
        private static byte[] combinationFound;
        private static byte[] finalCombinationFound;

        static void Main()
        {
            byte keyPresses = byte.Parse(Console.ReadLine());

            var directions = Console.ReadLine().ToCharArray();

            combinationNumberToShow = int.Parse(Console.ReadLine());
            combinationFound = new byte[keyPresses];
           
            var initialDirection = directions[0];
            byte depth = 1;
            switch (initialDirection)
            {
                case '<':
                    combinationFound[0] = 0;
                    FindCombination(directions, depth);
                    if (combinationIsFound)
                    {
                        break;
                    }
                    for (byte i = 1; i < 10; i++)
                    {
                        combinationFound[0] = i;
                        FindCombination(directions, depth);
                        if (combinationIsFound)
                        {
                            break;
                        }
                    }
                    break;
                case '>':
                   for (byte i = 1; i < 10; i++)
                    {
                        combinationFound[0] = i;
                        FindCombination(directions, depth);
                        if (combinationIsFound)
                        {
                            break;
                        }
                    }

                    break;
                case '=':
                   for (byte i = 0; i < 10; i++)
                    {
                        combinationFound[0] = i;
                        FindCombination(directions, depth);
                        if (combinationIsFound)
                        {
                            break;
                        }
                    }

                    combinationFound[0] = 0;
                    FindCombination(directions, depth);

                    break;
            }
            Console.WriteLine(string.Join("", finalCombinationFound));
        }

        private static void FindCombination(char[] directions, byte depth)
        {
            if (combinationIsFound)
            {
                return;
            }
            var currentDirection = directions[depth - 1];
            byte previousNum = combinationFound[depth - 1];
            if (depth == combinationFound.Length - 1)
            {
                if (combinationNumberToShow == currentCombinationCount)
                {
                    combinationIsFound = true;
                    finalCombinationFound = (byte[])combinationFound.Clone();
                    return;
                }

                else
                {
                    switch (currentDirection)
                    {
                        case '<':
                            if (previousNum == 1)
                            {
                                return;
                            }
                            if (previousNum == 0)
                            {
                                for (byte i = 1; i < 10; i++)
                                {
                                    combinationFound[depth] = i;
                                    currentCombinationCount++;
                                    if (combinationNumberToShow == currentCombinationCount)
                                    {
                                        combinationIsFound = true;
                                        finalCombinationFound = (byte[])combinationFound.Clone();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                for (byte i = 1; i < previousNum; i++)
                                {
                                    combinationFound[depth] = i;
                                    currentCombinationCount++;
                                    if (combinationNumberToShow == currentCombinationCount)
                                    {
                                        finalCombinationFound = (byte[])combinationFound.Clone();
                                        combinationIsFound = true;
                                        return;
                                    }
                                }
                            }
                            break;
                        case '>':
                            if (previousNum == 0)
                            {
                                return;
                            }

                            else if (previousNum == 9)
                            {
                                combinationFound[depth] = 0;
                                currentCombinationCount++;
                                if (combinationNumberToShow == currentCombinationCount)
                                {
                                    combinationIsFound = true;
                                    finalCombinationFound = (byte[])combinationFound.Clone();
                                    return;
                                }
                            }
                            else
                            {
                                combinationFound[depth] = 0;
                                currentCombinationCount++;
                                if (combinationNumberToShow == currentCombinationCount)
                                {
                                    combinationIsFound = true;
                                    finalCombinationFound = (byte[])combinationFound.Clone();
                                    return;
                                }
                                for (byte i = ++previousNum; i < 10; i++)
                                {
                                    combinationFound[depth] = i;
                                    currentCombinationCount++;
                                    if (combinationNumberToShow == currentCombinationCount)
                                    {
                                        combinationIsFound = true;
                                        finalCombinationFound = (byte[])combinationFound.Clone();
                                        return;
                                    }
                                }
                            }
                            break;
                        case '=':
                            combinationFound[depth] = previousNum;
                            currentCombinationCount++;
                            if (combinationNumberToShow == currentCombinationCount)
                            {
                                finalCombinationFound = (byte[])combinationFound.Clone();
                                combinationIsFound = true;
                            }
                            break;
                    }
                }
            }
            else
            {
                switch (currentDirection)
                {
                    case '<':
                        if (previousNum == 1)
                        {
                            return;
                        }
                        else if (previousNum == 0)
                        {
                            depth++;

                            for (byte i = 1; i < 10; i++)
                            {
                                combinationFound[depth - 1] = i;
                                FindCombination(directions, depth);
                            }
                        }
                        else
                        {
                            depth++;

                            for (byte i = 1; i < previousNum; i++)
                            {
                                combinationFound[depth - 1] = i;
                                FindCombination(directions, depth);
                            }
                        }
                        break;
                    case '>':
                        if (previousNum == 0)
                        {
                            return;
                        }
                        else if (previousNum == 9)
                        {
                            depth++;
                            combinationFound[depth - 1] = 0;
                            FindCombination(directions, depth);
                        }
                        else
                        {
                            depth++;

                            combinationFound[depth - 1] = 0;
                            FindCombination(directions, depth);

                            for (byte i = ++previousNum; i < 10; i++)
                            {
                                combinationFound[depth - 1] = i;
                                FindCombination(directions, depth);
                            }
                        }
                        break;
                    case '=':
                        combinationFound[depth] = previousNum;
                        FindCombination(directions, ++depth);
                        break;
                }
            }
        }
    }
}
