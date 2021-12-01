using System;
using System.Collections.Generic;
using System.IO;

namespace Day_1
{
    class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
        static void Main(string[] args)
        {
            string[] inputString = File.ReadAllLines(path);
            int[] input = Array.ConvertAll(inputString, int.Parse);

            Console.WriteLine(Part1(input));
            Console.WriteLine(Part2(input));
        }

        private static int Part2(int[] input)
        {
            int count = 0;

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < input.Length - 2; i++)
            {
                sum2 = 0;
                for (int j = 0; j < 3; j++)
                {
                    sum2 += input[i + j];
                }

                if (sum2 > sum1)
                {
                    count++;
                }

                sum1 = sum2;

            }


            return count - 1;
        }

        private static int Part1(int[] input)
        {
            int count = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] < input[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
