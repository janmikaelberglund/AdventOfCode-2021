using System;
using System.Collections.Generic;
using System.IO;

namespace Day_11
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
        static void Main(string[] args)
        {
            var rawInput = File.ReadAllText(path);

            List<int> input = new(Array.ConvertAll(rawInput.Split(','), int.Parse));

            Console.WriteLine(part1(new(input)));
            Console.WriteLine(part2(new(input)));
        }
        private static int part1(List<int> input)
        {


            return 0;
        }

        private static int part2(List<int> input)
        {
            throw new NotImplementedException();
        }
    }
}