using System;

namespace LeetCodeProblems.Problems
{
    class ProgramLinkedListDepth
    {
        void Main(string[] args)
        {
            var head = new Node(4);
            var nodeB = new Node(5);
            var nodeC = new Node(3);
            var nodeD = new Node(4);

            head.Next = nodeB;
            nodeB.Next = nodeC;
            nodeC.Next = nodeD;

            var count = FindLinkedListDepth(head);
            
            Console.WriteLine(count);

            Console.Read();
        }

        static int FindLinkedListDepth(Node node)
        {
            if (node == null)
                throw new Exception();

            return FindLinkedListDepthInternal(node, 0);
        }
        
        private static int FindLinkedListDepthInternal(Node node, int count)
        {
            if (node == null)
                return count;

            count++;

            count = FindLinkedListDepthInternal(node.Next, count);

            return count;
        }
    }

    class Node
    {
        private int Data;

        public Node Next;

        public Node(int data)
        {
            Data = data;
        }
    }
}