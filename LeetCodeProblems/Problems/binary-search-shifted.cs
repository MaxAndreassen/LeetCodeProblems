using System;

namespace LeetCodeProblems.Problems
{
    // Struggled with this one initially. Succeeded in the end, but it's worth retrying in the future.
    class ProgramBinarySearchShifted
    {
        void Main(string[] args)
        {
            var array = new[]
            {
                14, 19, 20, 21, 24, 1, 3
            };

            var target = 19;

            var position = BinarySearch(array, target);

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
                if (array[midPoint] > array[leftPointer])
                {
                    if (target >= array[leftPointer] && target < array[midPoint])
                        rightPointer = midPoint - 1;
                    else
                        leftPointer = midPoint + 1;
                }
                else
                {
                    if (target <= array[rightPointer] && target > array[midPoint])
                        leftPointer = midPoint + 1;
                    else
                        rightPointer = midPoint - 1;
                }

                midPoint = (leftPointer + rightPointer) / 2;
            }

            if (array[midPoint] == target)
                return midPoint;

            return -1;
        }
    }
}