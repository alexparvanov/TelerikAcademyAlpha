using System;
using System.Data.SqlTypes;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());


        string digitInWord = GetLastDigitAsEnglishWord(number);
        Console.WriteLine(digitInWord);
    }

    static string GetLastDigitAsEnglishWord(int number)
    {
        string numToString = number.ToString();
        char digitToChar = numToString[numToString.Length - 1];
        string word = String.Empty;
        switch (digitToChar)
        {

            case '1':
                word = "one";
                break;
            case '2':
                word = "two";
                break;
            case '3':
                word = "three";
                break;
            case '4':
                word = "four";
                break;
            case '5':
                word = "five";
                break;
            case '6':
                word = "six";
                break;
            case '7':
                word = "seven";
                break;
            case '8':
                word = "eight";
                break;
            case '9':
                word = "nine";
                break;
            case '0':
                word = "zero";
                break;
        }
        return word;
    }
}