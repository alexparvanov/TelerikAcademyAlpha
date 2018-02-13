using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MessagesInBottle
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretMessage = Console.ReadLine();
            string cipher = Console.ReadLine();
            string pattern = @"([A-Z]+)(\d+)";

            SortedDictionary<char, string> letterToCodeMap = new SortedDictionary<char, string>();
            MatchCollection matches = Regex.Matches(cipher, pattern);
            foreach (Match match in matches)
            {
                char letter = match.Groups[1].Value[0];
                string code = match.Groups[2].Value;
                if (!letterToCodeMap.ContainsKey(letter))
                {
                    letterToCodeMap.Add(letter, code);
                }
            }

            StringBuilder messageBuilder = new StringBuilder();
            List<string> originalMessages = new List<string>();
            DecodeMessages(secretMessage, letterToCodeMap, messageBuilder, originalMessages);

            Console.WriteLine(originalMessages.Count);
            if (originalMessages.Count > 0)
            {
                Console.WriteLine(string.Join("\n", originalMessages));
            }
        }

        public static void DecodeMessages(string secretMessage, SortedDictionary<char, string> letterToCodeMap, 
                                        StringBuilder messageBuilder, List<string> originalMessages)
        {
            if (secretMessage == string.Empty)
            {
                originalMessages.Add(messageBuilder.ToString());
                return;
            }

            foreach (var pair in letterToCodeMap)
            {
                char letter = pair.Key;
                string code = pair.Value;

                if (secretMessage.StartsWith(code))
                {
                    messageBuilder.Append(letter);

                    string restOfSecretMessage = secretMessage.Substring(code.Length);
                    DecodeMessages(restOfSecretMessage, letterToCodeMap, messageBuilder, originalMessages);

                    messageBuilder.Remove(messageBuilder.Length - 1, 1);
                }
            }
        }
    }
}
