using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace task03_SupermarketQueue
{
    class Program
    {
        static void Main()
        {
            var queue = new BigList<string>();

            var nameCount = new Dictionary<string, int>();

            var input = string.Empty;
            var results = new StringBuilder();
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var command = tokens[0];
                string currentName = string.Empty;

                switch (command)
                {
                    case "Append":
                        currentName = tokens[1];
                        queue.Add(currentName);
                        if (!nameCount.ContainsKey(currentName))
                        {
                            nameCount[currentName] = 0;
                        }
                        nameCount[currentName]++;
                        results.AppendLine("OK");
                        break;

                    case "Insert":

                        int position = int.Parse(tokens[1]);
                        currentName = tokens[2];
                        int currentCount = queue.Count;

                        if (position > currentCount || position < 0)
                        {
                            results.AppendLine("Error");
                            break;
                        }

                        queue.Insert(position, currentName);

                        if (!nameCount.ContainsKey(currentName))
                        {
                            nameCount[currentName] = 0;
                        }
                        nameCount[currentName]++;
                        results.AppendLine("OK");
                        break;

                    case "Find":
                        currentName = tokens[1];

                        results.AppendLine(nameCount.ContainsKey(currentName)
                            ? nameCount[currentName].ToString()
                            : 0.ToString());
                        break;

                    case "Serve":

                        int count = int.Parse(tokens[1]);
                        if (count > queue.Count || count < 1)
                        {
                            results.AppendLine("Error");
                        }
                        else
                        {
                            var currentServed = queue.Range(0, count).ToArray();
                            results.AppendLine(string.Join(" ", currentServed));

                            queue.RemoveRange(0, count);

                            foreach (var client in currentServed)
                            {
                                nameCount[client]--;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(results.ToString().Trim());
        }
    }
}
