using System;
using System.Collections;

namespace LeetCodeProblems.Problems
{
    class Program
    {
        void Main(string[] args)
        {
            var order = "hlabcdefgijkmnopqrstuvwxyz";
            var words = new string[]
            {
                "hello", "leetcode"
            };

            var result = IsAlienSorted(words, order);

            Console.WriteLine(result);

            Console.Read();
        }

        static bool IsAlienSorted(string[] words, string order)
        {
            var hashTable = new Hashtable();

            for (var i = 0; i < order.Length; i++)
            {
                hashTable.Add(order[i], i);
            }

            return CompareWords(words, hashTable, 0);
        }

        static bool CompareWords(string[] words, Hashtable order, int position)
        {
            if (position >= words.Length - 1)
                return true;

            var result = CompareWords(words, order, position + 1);

            if (result == true)
            {
                var word1 = words[position];
                var word2 = words[position + 1];

                if (word1 == word2)
                    return true;

                var index = 0;

                while (word1[index] == word2[index])
                {
                    index++;

                    if (index >= word1.Length)
                        return true;

                    if (index >= word2.Length)
                        return false;
                }

                var word1Score = 0;
                var word2Score = 0;

                word1Score = (int) order[word1[index]];
                word2Score = (int) order[word2[index]];

                if (word1Score < word2Score)
                    return true;
                else
                    return false;

            }
            else
            {
                return false;
            }
        }
    }
}