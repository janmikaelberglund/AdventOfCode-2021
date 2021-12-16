using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace Day_6
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
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
            List<List<int>> splitList30 = new();

            for (int i = 0; i < 30; i++)
            {
                splitList30.Add(new());
            }
            splitList30[0].Add(input);

            var redistribute = 0;
            for (int i = 256; i > 0; i--)
            {
                int splitListCount = splitList30.Count;
                List<int> countIntsInSplitList = new();
                for (int l = 0; l < splitListCount; l++)
                {
                    countIntsInSplitList.Add(splitList30[l].Count);
                }
                for (int j = 0; j < splitListCount; j++)
                {

                    for (int k = 0; k < countIntsInSplitList[j]; k++)
                    {
                        if (splitList30[j][k] == 0)
                        {
                            splitList30[redistribute].Add(8);
                            splitList30[j][k] = 6;
                        }
                        else
                        {
                            splitList30[j][k] --;
                        }
                        if (redistribute < 29)
                        {
                            redistribute++;
                        }
                        else
                        {
                            redistribute = 0;
                        }
                    }
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

        private static BigInteger part2b(int input)
        {
            List<List<int>> temp = new();

            for (int i = 0; i < 15; i++)
            {
                temp.Add(new());
            }
            temp[0].Add(input);

            for (int i = 256; i > 0; i--)
            {
                for (int j = 0; j < temp.Count; j++)
                {
                    int count = temp[j].Count;
                    for (int k = 0; k < temp[j].Count; k++)
                    {
                        if (temp[j][k] == 0)
                        {
                            if (j == 0)
                            {
                                temp[temp.Count - 1].Add(8);
                            }
                            else
                            {
                                temp[j - 1].Add(8);
                            }
                            temp[j][k] = 6;
                        }
                        else
                        {
                            temp[j][k]--;
                        }
                    }
                }
            }

            BigInteger counter = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                counter += temp[i].Count;
            }

            temp = null;

            return counter;
        }
    }
}
