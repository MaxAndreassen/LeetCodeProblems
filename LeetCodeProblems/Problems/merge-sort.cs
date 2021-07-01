using System;

namespace LeetCodeProblems.Problems
{
    class ProgramMergeSort
    {
        void Main(string[] args)
        {
            var array = new[]
            {
                2, 8, 7, 4, 5, 12, -1, 10, 3
            };

            array = MergeSort(array);

            for (var i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }

            Console.Read();
        }

        static int[] MergeSort(int[] array)
        {
            var headNode = DivideArray(array);

            var mergedHeadNode = MergeArray(headNode);

            return mergedHeadNode.Value;
        }

        static MergeSortNode MergeArray(MergeSortNode node)
        {
            if (node.Left == null || node.Right == null)
                return node;

            if (node.Left.Left != null || node.Left.Right != null)
                MergeArray(node.Left);

            if (node.Right.Left != null || node.Right.Right != null)
                MergeArray(node.Right);

            var combinedArray = new int[node.Left.Value.Length + node.Right.Value.Length];

            var i = 0;
            var j = 0;

            for (var x = 0; x < combinedArray.Length; x++)
            {
                if (i >= node.Left.Value.Length)
                {
                    combinedArray[x] = node.Right.Value[j];
                    j++;
                    continue;
                }
                
                if (j >= node.Right.Value.Length)
                {
                    combinedArray[x] = node.Left.Value[i];
                    i++;
                    continue;
                }
                
                if (node.Left.Value[i] < node.Right.Value[j])
                {
                    combinedArray[x] = node.Left.Value[i];
                    i++;
                }
                else
                {
                    combinedArray[x] = node.Right.Value[j];
                    j++;
                }
            }

            node.Value = combinedArray;
            node.Left = null;
            node.Right = null;
            
            return node;
        }
        
        static MergeSortNode DivideArray(int[] array)
        {
            if (array.Length <= 1)
                return new MergeSortNode(array);

            var arrays = SplitArray(array);
            
            var leftArrays = DivideArray(arrays[0]);
            var rightArrays = DivideArray(arrays[1]);
            
            var node = new MergeSortNode(array);
            node.Left = leftArrays;
            node.Right = rightArrays;

            return node;
        }

        static int[][] SplitArray(int[] array)
        {
            var middle = array.Length / 2;

            var subArrayLeft = new int[middle];
            var subArrayRight = new int[array.Length - middle];

            for (var i = 0; i < array.Length; i++)
            {
                if (i < middle)
                    subArrayLeft[i] = array[i];
                else
                    subArrayRight[i - middle] = array[i];
            }

            return new[]
            {
                subArrayLeft,
                subArrayRight
            };
        }
        
        class MergeSortNode
        {
            public MergeSortNode Left;

            public MergeSortNode Right;

            public int[] Value;

            public MergeSortNode(int[] value)
            {
                Value = value;
            }
        }
    }
}