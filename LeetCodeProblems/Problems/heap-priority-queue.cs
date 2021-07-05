using System;
using System.Collections.Generic;

namespace LeetCodeProblems.Problems
{
    class ProgramHeapPriorityQueue
    {
        void Main(string[] args)
        {
            var heap = new Heap();
            
            heap.Insert(4);
            heap.Insert(5);
            heap.Insert(3);
            heap.Insert(2);
            heap.Insert(10);
            heap.Insert(1);
            
            Console.WriteLine(heap.RemoveTop());
            Console.WriteLine(heap.RemoveTop());
            Console.WriteLine(heap.RemoveTop());
            Console.WriteLine(heap.RemoveTop());
            Console.WriteLine(heap.RemoveTop());
            Console.WriteLine(heap.RemoveTop());

            Console.Read();

        }

        class Heap
        {
            private List<int> Values { get; set; } = new List<int>();

            public Heap()
            {
                Values.Add(-1);
            }
            
            public void Insert(int value)
            {
                Values.Add(value);
                
                var index = Values.Count - 1;
                
                BubbleUp(index);
            }

            public int RemoveTop()
            {
                if (Values.Count <= 1)
                    return -1;
                
                var value = Values[1];
                
                var bottomValue = Values[^1];
                Values[1] = bottomValue;
                Values.RemoveAt(Values.Count - 1);
                
                SinkDown(1);

                return value;
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

                if (child2Index >= Values.Count || Values[child1Index] > Values[child2Index])
                {
                    if (value < Values[child1Index])
                    {
                        Values[index] = Values[child1Index];
                        Values[child1Index] = value;
                        SinkDown(child1Index);
                        return;
                    }
                }

                if (child2Index >= Values.Count)
                    return;

                if (value < Values[child2Index])
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

                if (parent < value)
                {
                    Values[parentIndex] = value;
                    Values[index] = parent;
                    BubbleUp(parentIndex);
                }
            }
        }
    }
}