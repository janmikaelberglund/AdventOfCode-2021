using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day_2
{
    class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
        static void Main(string[] args)
        {
            string[] inputString = File.ReadAllLines(path);

            List<Tuple<string, int>> directions = inputString
                .Select(s => new Tuple<string, int>(s.Split(' ')[0], int.Parse(s.Split(' ')[1])))
                .ToList();

            Console.WriteLine(Part1(directions));
            Console.WriteLine(Part2(directions));
        }

        private static BigInteger Part2(List<Tuple<string, int>> directions)
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            Dictionary<string, Action<int>> actions = new()
            {
                { "forward", x => 
                    { 
                        horizontal += x;
                        depth += x * aim;
                    } 
                },
                { "up", x => aim -= x },
                { "down", x => aim += x }
            };

            foreach (var direction in directions)
            {
                actions.First(d => d.Key == direction.Item1).Value(direction.Item2);
            }

            return horizontal * depth;
        }

        private static int Part1(List<Tuple<string, int>> directions)
        {
            int horizontal = 0;
            int depth = 0;

            Dictionary<string, Action<int>> actions = new()
            {
                { "forward", x => horizontal += x },
                { "up", x => depth -= x },
                { "down", x => depth += x }
            };

            foreach (var direction in directions)
            {
                actions.First(d => d.Key == direction.Item1).Value(direction.Item2);
            }

            return horizontal * depth;
        }

        
    }
}
