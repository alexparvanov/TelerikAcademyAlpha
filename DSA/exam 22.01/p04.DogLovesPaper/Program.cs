using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p04.DogLovesPaper
{
    class Program
    {
        static void Main()
        {
            var result = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            var childParents = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var child = 0;
                var parent = 0;
                if (input[2] == "after")
                {
                    child = int.Parse(input[0]);
                    parent = int.Parse(input[3]);
                }
                if (input[2] == "before")
                {
                    child = int.Parse(input[3]);
                    parent = int.Parse(input[0]);
                }
                if (!childParents.ContainsKey(child))
                {
                    childParents[child] = new HashSet<int>();
                }
                if (!childParents.ContainsKey(parent))
                {
                    childParents[parent] = new HashSet<int>();
                }
                childParents[child].Add(parent);
            }
            var parentless = childParents.Where(w => w.Value.Count == 0 && w.Key != 0).Select(s => s.Key).OrderBy(ob => ob).First();

            var queue = new Queue<int>();

            queue.Enqueue(parentless);
            childParents.Remove(parentless);

            while (queue.Count > 0)
            {
                var currentParent = queue.Dequeue();
                result.Append(currentParent);
                foreach (var child in childParents)
                {
                    if (child.Value.Contains(currentParent))
                    {
                        child.Value.Remove(currentParent);
                    }
                }
                if (childParents.Count == 0)
                {
                    break;
                }
                parentless = childParents.Where(w => w.Value.Count == 0).Select(s => s.Key).OrderBy(ob => ob).FirstOrDefault();

                queue.Enqueue(parentless);
                childParents.Remove(parentless);
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
