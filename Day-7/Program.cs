using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_7
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
            input = input.OrderBy(x => x).ToList();

            var fuelCount = int.MaxValue;

            for (int i = 0; i < input.Last(); i++)
            {
                var temp = FuelCounter(input, i);

                if (temp < fuelCount)
                {
                    fuelCount = temp;
                }
            }


            return fuelCount;
        }

        private static int FuelCounter(List<int> input, int i)
        {
            var horizontalLine = i;
            var fuelCount = 0;
            foreach (var sub in input)
            {
                fuelCount += Math.Abs(sub - horizontalLine);
            }

            return fuelCount;
        }

        private static int part2(List<int> input)
        {
            input = input.OrderBy(x => x).ToList();

            var fuelCount = int.MaxValue;

            for (int i = 0; i < input.Last(); i++)
            {
                var temp = FuelCounter2(input, i);

                if (temp < fuelCount)
                {
                    fuelCount = temp;
                }
            }

            return fuelCount;
        }

        private static int FuelCounter2(List<int> input, int i)
        {
            var horizontalLine = i;
            var fuelCount = 0;
            foreach (var sub in input)
            {
                var distance = Math.Abs(sub - horizontalLine);
                for (int j = 0; j < distance; j++)
                {
                    fuelCount += j + 1;
                }

            }

            return fuelCount;
        }
    }
}