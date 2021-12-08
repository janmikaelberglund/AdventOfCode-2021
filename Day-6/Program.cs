using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day_6
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(path);

            var split = input[0].Split(',');

            List<int> inputList = new List<int>(Array.ConvertAll(split, int.Parse));
            List<List<int>> biglist = new();

            foreach (var inp in inputList)
            {
                biglist.Add(new List<int>() {inp });
            }

            //System.Numerics.BigInteger bigint = new();
            //foreach (var fishList in biglist)
            //{
            //    bigint += part2(fishList);
            //}

            //Console.WriteLine(part1(new(inputList)));
            Console.WriteLine(part2(new List<int>() { 1 }));
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

        private static int part2(List<int> input)
        {
            for (int i = 256; i > 0; i--)
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
    }
}
