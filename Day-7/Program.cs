using System;
using System.IO;

namespace Day_7
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(path);


            Console.WriteLine(part1(input));
            Console.WriteLine(part2(input));
        }

        private static int part2(string[] input)
        {
            throw new NotImplementedException();
        }

        private static int part1(string[] input)
        {
            throw new NotImplementedException();
        }