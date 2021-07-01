using System;

namespace LeetCodeProblems.Problems
{
    class ProgramMergeSortLinkedList
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

            var newHead = MergeSort(head);

            var current = newHead;

            while (current != null)
            {
                Console.Write(current.Data + ", ");
                current = current.Next;
            }

            Console.Read();
        }

        static Node MergeSort(Node head)
        {
            var mergeSortNode = DivideLinkedList(head);

            mergeSortNode = MergeLinkedList(mergeSortNode);

            return mergeSortNode.Value;
        }

        static MergeSortNode MergeLinkedList(MergeSortNode mergeSortNode)
        {
            if (mergeSortNode.Left == null || mergeSortNode.Right == null)
                return mergeSortNode;

            if (mergeSortNode.Left.Left != null || mergeSortNode.Left.Right != null)
                MergeLinkedList(mergeSortNode.Left);

            if (mergeSortNode.Right.Left != null || mergeSortNode.Right.Right != null)
                MergeLinkedList(mergeSortNode.Right);

            var newHeadNode = MergeSortedLinkedList(mergeSortNode.Left.Value, mergeSortNode.Right.Value);

            mergeSortNode.Value = newHeadNode;
            mergeSortNode.Left = null;
            mergeSortNode.Right = null;

            return mergeSortNode;
        }

        static Node MergeSortedLinkedList(Node node1, Node node2)
        {
            if (node1 == null)
                return node2;

            if (node2 == null)
                return node1;

            if (node1.Data < node2.Data)
            {
                node1.Next = MergeSortedLinkedList(node1.Next, node2);
                return node1;
            }
            else
            {
                node2.Next = MergeSortedLinkedList(node2.Next, node1);
                return node2;
            }
        }

        static MergeSortNode DivideLinkedList(Node node)
        {
            if (node.Next == null)
                return new MergeSortNode(node);

            var nodes = SplitLinkedList(node);
            
            var leftNodes = DivideLinkedList(nodes[0]);
            var rightNodes = DivideLinkedList(nodes[1]);
            
            var mergeNode = new MergeSortNode(node);
            mergeNode.Left = leftNodes;
            mergeNode.Right = rightNodes;

            return mergeNode;
        }

        static Node[] SplitLinkedList(Node node)
        {
            var current = node;

            Node precedingMiddle = null;
            var middle = node;

            while (current != null)
            {
                current = current.Next?.Next;
                precedingMiddle = middle;
                middle = middle.Next;
            }

            if (precedingMiddle == null)
                throw new Exception();

            var secondHeadNode = middle;

            precedingMiddle.Next = null;

            return new[]
            {
                node,
                secondHeadNode
            };
        }
        
        class Node
        {
            public int Data;

            public Node Next;

            public Node(int data)
            {
                Data = data;
            }
        }
        
        class MergeSortNode
        {
            public MergeSortNode Left;

            public MergeSortNode Right;

            public Node Value;

            public MergeSortNode(Node value)
            {
                Value = value;
            }
        }
    }
}