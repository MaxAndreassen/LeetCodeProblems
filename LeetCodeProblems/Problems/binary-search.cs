using System;

namespace LeetCodeProblems.Problems
{
    class ProgramBinarySearch
    {
        void Main(string[] args)
        {
            var array = new []
            {
                1, 3, 6, 8, 9, 11, 13, 14, 19
            };
            
            var target = 20;

            var position = BinarySearchRecursive(array, target);
            
            Console.WriteLine(position);

            Console.Read();
        }

        static int BinarySearch(int[] array, int target)
        {
            if (array == null || array.Length == 0)
                return -1;
            
            var leftPointer = 0;
            var rightPointer = array.Length - 1;
            
            var midPoint = rightPointer / 2;

            while (array[midPoint] != target && leftPointer <= rightPointer)
            {
                if (array[midPoint] > target)
                {
                    rightPointer = midPoint - 1;
                }
                else
                {
                    leftPointer = midPoint + 1;
                }

                midPoint = (leftPointer + rightPointer) / 2;
            }

            if (array[midPoint] == target)
                return midPoint;

            return -1;
        }

        static int BinarySearchRecursive(int[] array, int target)
        {
            if (array == null || array.Length == 0)
                return -1;

            var finalSearchData = BinarySearchRecursiveInternal(array, target, new BinarySearchData(0, array.Length - 1));

            if (array[finalSearchData.MidPoint] == target)
                return finalSearchData.MidPoint;

            return -1;
        }

        static BinarySearchData BinarySearchRecursiveInternal(int[] array, int target, BinarySearchData searchData)
        {
            searchData.MidPoint = (searchData.LeftPointer + searchData.RightPointer) / 2;
            
            if (array[searchData.MidPoint] == target || searchData.LeftPointer > searchData.RightPointer)
                return searchData;
            
            if (array[searchData.MidPoint] > target)
            {
                searchData.RightPointer = searchData.MidPoint - 1;
                searchData = BinarySearchRecursiveInternal(array, target, searchData);
            }
            else
            {
                searchData.LeftPointer = searchData.MidPoint + 1;
                searchData = BinarySearchRecursiveInternal(array, target, searchData);
            }

            return searchData;
        }
    }

    class BinarySearchData
    {
        public int LeftPointer;

        public int RightPointer;

        public int MidPoint;

        public BinarySearchData(
            int leftPointer,
            int rightPointer
        )
        {
            LeftPointer = leftPointer;
            RightPointer = rightPointer;
        }
    }
}