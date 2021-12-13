using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_8
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "example.txt");
        static void Main(string[] args)
        {
            var rawInput = File.ReadAllLines(path);

            List<List<string>> input = new();

            foreach (var rawLine in rawInput)
            {
                var split = rawLine.Split(" | ");
                input.Add(new(split[1].Split(' ')));
            }


            Console.WriteLine(part1(new(input)));
            Console.WriteLine(part2(new(input)));
        }
        private static int part1(List<List<string>> input)
        {
            var count = 0;
            foreach (var list in input)
            {
                foreach (var str in list)
                {
                    var condition = str.Length == 2 || str.Length == 3 || str.Length == 4 || str.Length == 7;
                    if (condition)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static int part2(List<List<string>> input)
        {
            List<int> result = new();
            foreach (var list in input)
            {
                result.Add(DecodeNumber(list));
            }


            return result.Sum(x => x);
        }

        private static int DecodeNumber(List<string> list)
        {
            string result = "";

            string one = list.FirstOrDefault(x => x.Length == 2);
            string seven = list.FirstOrDefault(x => x.Length == 3);
            string four = list.FirstOrDefault(x => x.Length == 4);
            string eight = list.FirstOrDefault(x => x.Length == 7);
            string zero;
            string nine;
            if (four is not null)
            {
                string zeroOrSix = list.FirstOrDefault(x => x.Length == 6 && x.Count(y => four.Contains(y)) == 3);
                if (zeroOrSix is not null)
                {
                    zero = zeroOrSix.Count(x => seven.Contains(x)) == 3 ? zeroOrSix : null;
                }
                nine = list.FirstOrDefault(x => x.Length == 6 && x.Count(y => four.Contains(y)) == 4);
            }

            //Finish all conditions

            return int.Parse(result);
        }
    }
}