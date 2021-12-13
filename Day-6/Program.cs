using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace Day_6
{
    internal class Program
    {
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
                bigint += part2(fish);
                GC.Collect();
                count++;
                Console.WriteLine(count);
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
            List<List<int>> temp = new();

            for (int i = 0; i < 30; i++)
            {
                temp.Add(new());
            }
            temp[0].Add(input);

            for (int i = 256; i > 0; i--)
            {
                for (int j = 0; j < temp.Count; j++)
                {
                    int count = temp[j].Count;
                    var split = 0;
                    for (int k = 0; k < count; k++)
                    {
                        if (temp[j][k] == 0)
                        {
                            temp[split].Add(8);
                            temp[j][k] = 6;
                        }
                        else
                        {
                            temp[j][k] --;
                        }
                        if (split < 29)
                        {
                            split++;
                        }
                        else
                        {
                            split = 0;
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
