using System;
using System.Collections.Generic;

namespace LeetCodeProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = KClosest(new int[][]
            {
                new[] {3, 3},
                new[] {5, -1},
                new[] {-2, 4}
            }, 2);
            Console.Read();
        }

        public static int[][] KClosest(int[][] points, int k)
        {
            var priorityQueue = new Heap<int[]>();

            for (var i = 0; i < points.Length; i++)
            {
                var distance = DistanceFromOrigin(points[i][0], points[i][1]);

                priorityQueue.Insert(new HeapObject<int[]>(distance, points[i]));
            }

            var newPoints = new int[k][];

            for (var i = 0; i < k; i++)
            {
                newPoints[i] = priorityQueue.RemoveTop();
            }

            return newPoints;
        }

        public static int DistanceFromOrigin(int x, int y)
        {
            return (int) Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        class HeapObject<T> where T : class
        {
            public readonly int Comparer;
            public readonly T Data;

            public HeapObject(int comparer, T data)
            {
                Comparer = comparer;
                Data = data;
            }
        }

        class Heap<T> where T : class
        {
            private List<HeapObject<T>> Values { get; set; } = new List<HeapObject<T>>();

            public Heap()
            {
                Values.Add(null);
            }

            public void Insert(HeapObject<T> value)
            {
                Values.Add(value);

                var index = Values.Count - 1;

                BubbleUp(index);
            }

            public T RemoveTop()
            {
                if (Values.Count <= 1)
                    return null;

                var value = Values[1];

                var bottomValue = Values[^1];
                Values[1] = bottomValue;
                Values.RemoveAt(Values.Count - 1);

                SinkDown(1);

                return value.Data;
            }

            private void SinkDown(int index)
            {
                if (index >= Values.Count)
                    return;

                var value = Values[index];

                var child1Index = index * 2;

                if (child1Index >= Values.Count)
                    return;

                var child2Index = child1Index + 1;

                if (child2Index >= Values.Count || Values[child1Index].Comparer < Values[child2Index].Comparer)
                {
                    if (value.Comparer > Values[child1Index].Comparer)
                    {
                        Values[index] = Values[child1Index];
                        Values[child1Index] = value;
                        SinkDown(child1Index);
                        return;
                    }
                }

                if (value.Comparer > Values[child2Index].Comparer)
                {
                    Values[index] = Values[child2Index];
                    Values[child2Index] = value;
                    SinkDown(child2Index);
                }
            }

            private void BubbleUp(int index)
            {
                var value = Values[index];

                var parentIndex = index / 2;

                if (parentIndex < 1)
                    return;

                var parent = Values[parentIndex];

                if (parent.Comparer > value.Comparer)
                {
                    Values[parentIndex] = value;
                    Values[index] = parent;
                    BubbleUp(parentIndex);
                }
            }
        }
    }
}