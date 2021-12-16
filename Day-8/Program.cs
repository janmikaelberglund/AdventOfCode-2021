using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_8
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
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
            Console.WriteLine(part2(rawInput));
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

        private static int part2(string[] input)
        {
            List<int> result = new();
            foreach (var line in input)
            {
                result.Add(DecodeNumber(line));
            }

            return result.Sum(x => x);
        }

        private static int DecodeNumber(string input)
        {
            List<string> allNumbers = input.Split(" | ")[0].Split(' ').ToList();
            List<string> list2 = input.Split(" | ")[1].Split(' ').ToList();

            string result = "";

            var one = allNumbers.FirstOrDefault(x => x.Length == 2);
            allNumbers.Remove(one);
            var seven = allNumbers.FirstOrDefault(x => x.Length == 3);
            allNumbers.Remove(seven);
            var four = allNumbers.FirstOrDefault(x => x.Length == 4);
            allNumbers.Remove(four);
            var eight = allNumbers.FirstOrDefault(x => x.Length == 7);
            allNumbers.Remove(eight);
            var three = allNumbers.FirstOrDefault(x => x.Length == 5 && x.Count(y => one.Contains(y)) == 2);
            allNumbers.Remove(three);
            var two = allNumbers.FirstOrDefault(x => x.Length == 5 && x.Count(y => three.Contains(y)) == 4 && x.Count(y => four.Contains(y)) == 2);
            allNumbers.Remove(two);
            var five = allNumbers.FirstOrDefault(x => x.Length == 5);
            allNumbers.Remove(five);
            var nine = allNumbers.FirstOrDefault(x => x.Length == 6 && x.Count(y => three.Contains(y)) == 5);
            allNumbers.Remove(nine);
            var zero = allNumbers.FirstOrDefault(x => x.Length == 6 && x.Count(y => one.Contains(y)) == 2);
            allNumbers.Remove(zero);
            var six = allNumbers.FirstOrDefault(x => x.Length == 6);

            for (int i = 0; i < list2.Count; i++)
            {
                if (list2[i].Count(x => one.Contains(x)) == one.Length && list2[i].Length == one.Length)
                {
                    result += 1;
                }
                if (list2[i].Count(x => two.Contains(x)) == two.Length && list2[i].Length == two.Length)
                {
                    result += 2;
                }
                if (list2[i].Count(x => three.Contains(x)) == three.Length && list2[i].Length == three.Length)
                {
                    result += 3;
                }
                if (list2[i].Count(x => four.Contains(x)) == four.Length && list2[i].Length == four.Length)
                {
                    result += 4;
                }
                if (list2[i].Count(x => five.Contains(x)) == five.Length && list2[i].Length == five.Length)
                {
                    result += 5;
                }
                if (list2[i].Count(x => six.Contains(x)) == six.Length && list2[i].Length == six.Length)
                {
                    result += 6;
                }
                if (list2[i].Count(x => seven.Contains(x)) == seven.Length && list2[i].Length == seven.Length)
                {
                    result += 7;
                }
                if (list2[i].Count(x => eight.Contains(x)) == eight.Length && list2[i].Length == eight.Length)
                {
                    result += 8;
                }
                if (list2[i].Count(x => nine.Contains(x)) == nine.Length && list2[i].Length == nine.Length)
                {
                    result += 9;
                }
                if (list2[i].Count(x => zero.Contains(x)) == zero.Length && list2[i].Length == zero.Length)
                {
                    result += 0;
                }
            }

            //Finish all conditions

            return int.Parse(result);
        }
    }
}