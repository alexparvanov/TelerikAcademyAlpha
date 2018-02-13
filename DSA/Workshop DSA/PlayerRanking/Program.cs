using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            BigList<Player> playersRanklist = new BigList<Player>();
            Dictionary<string, OrderedSet<Player>> playersByType = new Dictionary<string, OrderedSet<Player>>();
            StringBuilder resultBuilder = new StringBuilder();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandParams = command.Split();
                switch (commandParams[0])
                {
                    case "add":
                        AddPlayer(playersRanklist, playersByType, resultBuilder, commandParams);
                        break;
                    case "find":
                        FindType(playersByType, resultBuilder, commandParams);
                        break;
                    case "ranklist":
                        GetRanklist(playersRanklist, resultBuilder, commandParams);
                        break;
                }
            }

            Console.WriteLine(resultBuilder.ToString());
        }

        private static void AddPlayer(BigList<Player> playersRanklist, Dictionary<string, OrderedSet<Player>> playersByType, StringBuilder resultBuilder, string[] commandParams)
        {
            string name = commandParams[1];
            string type = commandParams[2];
            int age = int.Parse(commandParams[3]);
            int position = int.Parse(commandParams[4]);

            Player playerToAdd = new Player(name, type, age);

            if (playersByType.ContainsKey(type))
            {
                if (playersByType[type].Count == 5)
                {
                    Player lastPlayer = playersByType[type][4];
                    if (lastPlayer.CompareTo(playerToAdd) > 0)
                    {
                        playersByType[type].Remove(lastPlayer);
                        playersByType[type].Add(playerToAdd);
                    }
                }
                else
                {
                    playersByType[type].Add(playerToAdd);
                }
            }
            else
            {
                playersByType[type] = new OrderedSet<Player>();
                playersByType[type].Add(playerToAdd);
            }

            playersRanklist.Insert(position - 1, playerToAdd);

            resultBuilder.AppendFormat("Added player {0} to position {1}", playerToAdd.Name, position);
            resultBuilder.AppendLine();
        }

        private static void FindType(Dictionary<string, OrderedSet<Player>> playersByType, StringBuilder resultBuilder, string[] commandParams)
        {
            string findType = commandParams[1];
            if (playersByType.ContainsKey(findType))
            {
                var players = playersByType[findType];
                resultBuilder.AppendFormat("Type {0}:", findType);
                foreach (Player player in players)
                {
                    resultBuilder.AppendFormat(" {0};", player);
                }

                resultBuilder.Remove(resultBuilder.Length - 1, 1);
                resultBuilder.AppendLine();
            }
            else
            {
                resultBuilder.AppendFormat("Type {0}: ", findType);
                resultBuilder.AppendLine();
            }
        }

        private static void GetRanklist(BigList<Player> playersRanklist, StringBuilder resultBuilder, string[] commandParams)
        {
            int start = int.Parse(commandParams[1]);
            int end = int.Parse(commandParams[2]);
            int count = end - start + 1;
            var rankedPlayers = playersRanklist.Range(start - 1, count);

            int playerPosition = start;
            foreach (Player player in rankedPlayers)
            {
                resultBuilder.AppendFormat("{0}. {1}; ", playerPosition++, player);
            }

            resultBuilder.Remove(resultBuilder.Length - 2, 2);
            resultBuilder.AppendLine();
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public Player(string name, string type, int age)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
        }

        public int CompareTo(Player other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age) * -1;
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }
}