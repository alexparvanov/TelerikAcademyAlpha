using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task01_StudentsOrder
{
    class Program
    {
        static void Main()
        {
            var parameters = Console.ReadLine().Split();
            var studentsCount = int.Parse(parameters[0]);
            var changeCount = int.Parse(parameters[1]);

            var namesNodes = new Dictionary<string, ListNode>(studentsCount);

            var initialStudentOrder = Console.ReadLine().Split().ToArray();

            namesNodes.Add(initialStudentOrder[0], new ListNode(initialStudentOrder[0]));
            var currentPreviousStudentNode = namesNodes[initialStudentOrder[0]];
            var currentInitialStudentNode = currentPreviousStudentNode;
            for (int i = 1; i < studentsCount; i++)
            {
                namesNodes.Add(initialStudentOrder[i], new ListNode(initialStudentOrder[i]));
                var currentStudentNode = namesNodes[initialStudentOrder[i]];
                currentPreviousStudentNode.NextNode = currentStudentNode;
                currentStudentNode.PrevNode = currentPreviousStudentNode;
                currentPreviousStudentNode = currentStudentNode;
            }

            if (studentsCount == 1)
            {
                Console.WriteLine(initialStudentOrder[0]);
                return;
            }

            for (int i = 0; i < changeCount; i++)
            {
                var currentChange = Console.ReadLine().Split();

                var leftStudentNode = namesNodes[currentChange[0]];
                var rightStudentNode = namesNodes[currentChange[1]];

                var previousOfLeftStudentNode = leftStudentNode.PrevNode;
                var nextOfLeftStudentNode = leftStudentNode.NextNode;
                var previousOfRightStudentNode = rightStudentNode.PrevNode;
                var nextOfRightStudentNode = rightStudentNode.NextNode;

                if (previousOfRightStudentNode == leftStudentNode)
                {
                    continue;
                }

                if (leftStudentNode == rightStudentNode)
                {
                    continue;
                }

                if (previousOfLeftStudentNode == null && nextOfRightStudentNode == null) // ляв първи десен последен
                {
                    currentInitialStudentNode = nextOfLeftStudentNode;
                    nextOfLeftStudentNode.PrevNode = null;
                    previousOfRightStudentNode.NextNode = leftStudentNode;
                    leftStudentNode.PrevNode = previousOfRightStudentNode;
                    leftStudentNode.NextNode = rightStudentNode; // rightStudentNode ни интересува само преди него да е leftStudentNode!
                    rightStudentNode.PrevNode = leftStudentNode; // rightStudentNode ни интересува само какъв е .PrevNode!
                }

                else if (nextOfRightStudentNode != null && previousOfLeftStudentNode == null) // ляв първи десен по средата
                {
                    currentInitialStudentNode = nextOfLeftStudentNode;
                    nextOfLeftStudentNode.PrevNode = null;
                    previousOfRightStudentNode.NextNode = leftStudentNode;
                    leftStudentNode.PrevNode = previousOfRightStudentNode;
                    leftStudentNode.NextNode = rightStudentNode; // rightStudentNode ни интересува само преди него да е leftStudentNode!
                    rightStudentNode.PrevNode = leftStudentNode; // rightStudentNode ни интересува само какъв е .PrevNode!
                }
                else if (previousOfRightStudentNode == null && nextOfLeftStudentNode == null) // ляв последен десен първи
                {
                    currentInitialStudentNode = leftStudentNode;
                    previousOfLeftStudentNode.NextNode = null;
                    leftStudentNode.NextNode = rightStudentNode; // rightStudentNode ни интересува само преди него да е leftStudentNode!
                    rightStudentNode.PrevNode = leftStudentNode; // rightStudentNode ни интересува само какъв е .PrevNode!
                    leftStudentNode.PrevNode = null;

                }
                else if (previousOfRightStudentNode != null && nextOfLeftStudentNode == null) // ляв последен десен по средата
                {
                    previousOfLeftStudentNode.NextNode = null;

                    previousOfRightStudentNode.NextNode = leftStudentNode;
                    leftStudentNode.PrevNode = previousOfRightStudentNode;

                    leftStudentNode.NextNode = rightStudentNode; // rightStudentNode ни интересува само преди него да е leftStudentNode!
                    rightStudentNode.PrevNode = leftStudentNode; // rightStudentNode ни интересува само какъв е .PrevNode!

                }

                else if (nextOfLeftStudentNode != null && previousOfRightStudentNode == null) // ляв по средата десен първи
                {
                    currentInitialStudentNode = leftStudentNode;
                    leftStudentNode.PrevNode = null;
                    previousOfLeftStudentNode.NextNode = nextOfLeftStudentNode;
                    nextOfLeftStudentNode.PrevNode = previousOfLeftStudentNode;
                    leftStudentNode.NextNode = rightStudentNode; // rightStudentNode ни интересува само преди него да е leftStudentNode!
                    rightStudentNode.PrevNode = leftStudentNode; // rightStudentNode ни интересува само какъв е .PrevNode!
                }

                else if (nextOfRightStudentNode == null && previousOfLeftStudentNode != null) // ляв по средата десен последен
                {
                    previousOfLeftStudentNode.NextNode = nextOfLeftStudentNode;
                    nextOfLeftStudentNode.PrevNode = previousOfLeftStudentNode;
                    previousOfRightStudentNode.NextNode = leftStudentNode;
                    leftStudentNode.PrevNode = previousOfRightStudentNode;

                    leftStudentNode.NextNode = rightStudentNode; // rightStudentNode ни интересува само преди него да е leftStudentNode!
                    rightStudentNode.PrevNode = leftStudentNode; // rightStudentNode ни интересува само какъв е .PrevNode!
                }
                else /*if (nextOfLeftStudentNode != null && previousOfLeftStudentNode != null && previousOfRightStudentNode != null && nextOfRightStudentNode != null) // ако са по средата?*/
                {
                    previousOfLeftStudentNode.NextNode = nextOfLeftStudentNode;
                    nextOfLeftStudentNode.PrevNode = previousOfLeftStudentNode;

                    leftStudentNode.PrevNode = previousOfRightStudentNode;
                    previousOfRightStudentNode.NextNode = leftStudentNode;
                    leftStudentNode.NextNode = rightStudentNode; // rightStudentNode ни интересува само преди него да е leftStudentNode!
                    rightStudentNode.PrevNode = leftStudentNode; // rightStudentNode ни интересува само какъв е .PrevNode!
                }
            }

            var outputResult = new StringBuilder(studentsCount);
            while (currentInitialStudentNode != null)
            {
                outputResult.Append(currentInitialStudentNode.Value + " ");
                currentInitialStudentNode = currentInitialStudentNode.NextNode;
            }

            Console.WriteLine(outputResult.ToString().Trim());
        }
    }

    public class ListNode
    {
        public string Value { get; private set; }

        public ListNode NextNode { get; set; }

        public ListNode PrevNode { get; set; }

        public ListNode(string value)
        {
            this.Value = value;
        }
    }
}