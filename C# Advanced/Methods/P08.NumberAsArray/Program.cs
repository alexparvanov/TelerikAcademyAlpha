using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        var arraySizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var firstArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var secondArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

        CalculateArrays(firstArray, secondArray);
    }

    static void CalculateArrays(int[] firstArray, int[] secondArray)
    {
        var firstNumSb = new StringBuilder();
        for (int i = firstArray.Length - 1; i >= 0; i--)
        {
            firstNumSb.Append(firstArray[i]);
        }

        var secondNumSb = new StringBuilder();
        for (int i = secondArray.Length - 1; i >= 0; i--)
        {
            secondNumSb.Append(secondArray[i]);
        }
        string inputNum1 = firstNumSb.ToString();
        string inputNum2 = secondNumSb.ToString();

        var firstLength = inputNum1.Length;
        var secondLength = inputNum2.Length;

        StringBuilder currentTotalNum = new StringBuilder();

        if (firstLength > secondLength)
        {
            int difference = firstLength - secondLength;
            int numToTransfer = 0;
            for (int i = inputNum1.Length - 1; i >= difference; i--)
            {
                int currentNumToString = 0;
                string currentStringNum1 = inputNum1[i].ToString();
                string currentStringNum2 = inputNum2[i - difference].ToString();
                int currentNum1 = int.Parse(currentStringNum1);
                int currentNum2 = int.Parse(currentStringNum2);
                if (currentNum1 + currentNum2 + numToTransfer > 9)
                {
                    currentNumToString = currentNum1 + currentNum2 + numToTransfer - 10;
                    numToTransfer = 1;
                }
                else
                {
                    currentNumToString = currentNum1 + currentNum2 + numToTransfer;
                    numToTransfer = 0;
                }
                currentTotalNum.Append(currentNumToString + " ");
            }


            for (int i = difference - 1; i >= 0; i--)
            {
                string currentStringNum1 = inputNum1[i].ToString();
                int currentNum1 = int.Parse(currentStringNum1);

                int currentNumToString = 0;

                if (currentNum1 + numToTransfer > 9)
                {
                    currentNumToString = currentNum1 + numToTransfer - 10;
                    numToTransfer = 1;
                }
                else
                {
                    currentNumToString = currentNum1 + numToTransfer;
                    numToTransfer = 0;
                }
                currentTotalNum.Append(currentNumToString + " ");
            }
            if (numToTransfer != 0)
            {
                currentTotalNum.Append(numToTransfer + " ");
            }
        }

        else if (secondLength > firstLength)
        {
            int difference = secondLength - firstLength;
            int numToTransfer = 0;
            for (int i = inputNum2.Length - 1; i >= difference; i--)
            {
                int currentNumToString = 0;
                string currentStringNum1 = inputNum1[i - difference].ToString();
                string currentStringNum2 = inputNum2[i].ToString();
                int currentNum1 = int.Parse(currentStringNum1);
                int currentNum2 = int.Parse(currentStringNum2);
                if (currentNum1 + currentNum2 + numToTransfer > 9)
                {
                    currentNumToString = currentNum1 + currentNum2 + numToTransfer - 10;
                    numToTransfer = 1;
                }
                else
                {
                    currentNumToString = currentNum1 + currentNum2 + numToTransfer;
                    numToTransfer = 0;
                }
                currentTotalNum.Append(currentNumToString + " ");
            }

            for (int i = difference - 1; i >= 0; i--)
            {
                string currentStringNum2 = inputNum2[i].ToString();
                int currentNum2 = int.Parse(currentStringNum2);

                int currentNumToString = 0;

                if (currentNum2 + numToTransfer > 9)
                {
                    currentNumToString = currentNum2 + numToTransfer - 10;
                    numToTransfer = 1;
                }
                else
                {
                    currentNumToString = currentNum2 + numToTransfer;
                    numToTransfer = 0;
                }
                currentTotalNum.Append(currentNumToString + " ");
            }
            if (numToTransfer != 0)
            {
                currentTotalNum.Append(numToTransfer + " ");
            }
        }
        else if (secondLength == firstLength)
        {
            int numToTransfer = 0;
            for (int i = inputNum2.Length - 1; i >= 0; i--)
            {
                int currentNumToString = 0;
                string currentStringNum1 = inputNum1[i].ToString();
                string currentStringNum2 = inputNum2[i].ToString();
                int currentNum1 = int.Parse(currentStringNum1);
                int currentNum2 = int.Parse(currentStringNum2);
                if (currentNum1 + currentNum2 + numToTransfer > 9)
                {
                    currentNumToString = currentNum1 + currentNum2 + numToTransfer - 10;
                    numToTransfer = 1;
                }
                else
                {
                    currentNumToString = currentNum1 + currentNum2 + numToTransfer;
                    numToTransfer = 0;
                }
                currentTotalNum.Append(currentNumToString + " ");
            }
            if (numToTransfer != 0)
            {
                currentTotalNum.Append(numToTransfer + " ");
            }
        }

        
        Console.WriteLine(currentTotalNum.ToString().Trim());
    }
}