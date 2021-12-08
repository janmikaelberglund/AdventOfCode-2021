using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day_5
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(path);

            var inputList = new List<List<int>>();

            foreach (var line in input)
            {
                var lineList = new List<int>();
                var regexMatch = Regex.Split(line, @"\D");
                foreach (var match in regexMatch)
                {
                    if (!string.IsNullOrEmpty(match))
                    {
                        lineList.Add(int.Parse(match));
                    }
                }
                inputList.Add(lineList);
            }


            Console.WriteLine(part1(inputList));
            Console.WriteLine(part2(inputList));
        }

        private static int part2(List<List<int>> input)
        {
            return 0;
        }

        private static int part1(List<List<int>> input)
        {
            input.RemoveAll(x => x[0] != x[2] && x[1] != x[3]);

            for (int i = 0; i < 999; i++)
            {
                for (int j = 0; j < 999; j++)
                {

                }
            }

            return 0;
        }
    }
}
