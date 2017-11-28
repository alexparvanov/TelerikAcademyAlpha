using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string wordToSearch = Console.ReadLine();
        var textInput = Console.ReadLine()
            .Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .Select(m => m += ".")
            .ToArray();
        
        var sb = new StringBuilder();

        foreach (var sentence in textInput)
        {
            string currentSentence = sentence;
            do
            {
                int indexOfWord = currentSentence.IndexOf(wordToSearch);
                //string initialWordToSearch = wordToSearch[0].ToString().ToUpper() + wordToSearch.Substring(1);
                //if (sentence.IndexOf(initialWordToSearch) == 0)
                //{
                //    if (!char.IsLetter(sentence[initialWordToSearch.Length]))
                //    {
                //        sb.Append(sentence + " ");
                //        break;
                //    }
                //}

                if (indexOfWord == -1)
                {
                    break;
                }

                bool charBeforeIsNotLetter = true;
                if (indexOfWord > 0)
                {
                    charBeforeIsNotLetter = !Char.IsLetter(currentSentence[indexOfWord - 1]);
                }
                bool charAfterIsNotLetter = true;
                if (indexOfWord + wordToSearch.Length < currentSentence.Length - 1)
                {
                    charAfterIsNotLetter = !Char.IsLetter(currentSentence[indexOfWord + wordToSearch.Length]);
                }
                
                if (indexOfWord != -1)
                {
                    if (charBeforeIsNotLetter && charAfterIsNotLetter)
                    {
                        sb.Append(sentence + " ");
                        break;
                    }
                    currentSentence = currentSentence.Substring(indexOfWord + wordToSearch.Length);
                }
            } while (true);
        }
        Console.WriteLine(sb.ToString().Trim());
    }
}