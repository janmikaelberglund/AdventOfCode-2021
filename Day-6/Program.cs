using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;

namespace Day_6
{
    internal class Program
    {
        public static List<List<int>> splitList30 = new();

        public static string path = Path.Combine(Environment.CurrentDirectory, "example.txt");
        static void Main(string[] args)
        {
            string[] inputRaw = File.ReadAllLines(path);

            var split = inputRaw[0].Split(',');

            List<int> inputList = new List<int>(Array.ConvertAll(split, int.Parse));

            BigInteger bigint = new();
            var count = 0;
            foreach (var fish in inputList)
            {
                count++;
                Console.WriteLine(count);
                bigint += part2(fish);
                GC.Collect();
            }

            Console.WriteLine(part1(new(inputList)));
            Console.WriteLine(bigint);
        }
        private static int part1(List<int> input)
        {
            for (int i = 80; i > 0; i--)
            {
                int count = input.Count;
                for (int j = 0; j < count; j++)
                {
                    if (input[j] == 0)
                    {
                        input.Add(8);
                        input[j] = 6;
                    }
                    else
                    {
                        input[j]--;
                    }
                }
            }

            return input.Count;
        }

        private static BigInteger part2(int input)
        {
            int numberOfLists = 16;
            for (int i = 0; i < numberOfLists; i++)
            {
                splitList30.Add(new());
            }
            splitList30[0].Add(input);

            for (int i = 80; i > 0; i--)
            {
                List<int> countIntsInSplitList = new();
                for (int l = 0; l < numberOfLists; l++)
                {
                    countIntsInSplitList.Add(splitList30[l].Count);
                }
                for (int j = 0; j < numberOfLists - 1; j++)
                {
                    //if (j % 2 != 0)
                    //{
                    //    continue;
                    //}
                    Task runLoop = Task.Run(() => AddFish(countIntsInSplitList, j));
                    //AddFish(countIntsInSplitList, j);
                    Task.WaitAll();
                }
            }

            BigInteger counter = 0;
            for (int i = 0; i < splitList30.Count; i++)
            {
                counter += splitList30[i].Count;
            }

            splitList30 = new();
            
            return counter;
        }

        private static void AddFish(List<int> countIntsInSplitList, int j)
        {
            var redistribute = 0;
            for (int k = 0; k < countIntsInSplitList[j]; k++)
            {
                if (splitList30[j][k] == 0)
                {
                    splitList30[redistribute].Add(8);
                    splitList30[j][k] = 6;
                }
                else
                {
                    splitList30[j][k]--;
                }
                if (redistribute < j + 1)
                {
                    redistribute++;
                }
                else
                {
                    redistribute = j;
                }
            }
        }
    }
}
