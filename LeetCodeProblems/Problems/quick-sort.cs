using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCodeProblems.Problems
{
    class ProgramQuickSort
    {
        void Main(string[] args)
        {
            var array = new[]
            {
                6, 7, 1, 2, 4, 5
            };

            var hashTable = new Hashtable();
            hashTable.Add('a', 0);

            var list = new List<int>();
            var test2 = list[0];
            
            var test = (int)hashTable['a'];

            var sortedArray = QuickSort(array);

            foreach (var i in sortedArray)
            {
                Console.Write(i + ", ");
            }

            Console.Read();
        }

        static int[] QuickSort(int[] array)
        {
            if (array == null || array.Length == 0)
                return array;

            QuickSortInternal(array, 0, array.Length - 1);

            return array;

        }

        static void QuickSortInternal(int[] array, int leftPointer, int rightPointer)
        {
            if (leftPointer >= rightPointer)
                return;

            var pivot = Partition(array, leftPointer, rightPointer);

            QuickSortInternal(array, leftPointer, pivot - 1);
            QuickSortInternal(array, pivot + 1, rightPointer);
        }

        static int Partition(int[] array, int leftPointer, int rightPointer)
        {
            var pivot = array[rightPointer];

            var smallerDepth = leftPointer - 1;

            for (var i = leftPointer; i < rightPointer; i++)
            {
                if (array[i] < pivot)
                {
                    smallerDepth++;
                    Swap(array, i, smallerDepth);
                }
            }
            
            Swap(array, smallerDepth + 1, rightPointer);

            return smallerDepth + 1;
        }

        static void Swap(int[] array, int pos1, int pos2)
        {
            var temp = array[pos1];
            array[pos1] = array[pos2];
            array[pos2] = temp;
        }
    }
}