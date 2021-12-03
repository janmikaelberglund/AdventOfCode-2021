using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_3
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(path);

            Console.WriteLine(Part1(input));
            Console.WriteLine(Part2(input));
        }

        private static int Part2(string[] input)
        {
            var oxy = input;
            var co = input;

            for (int i = 0; i < oxy[0].Length; i++)
            {
                if (oxy.Length > 1)
                {
                    oxy = ReduceList(oxy, i, saveLargerList: true);
                }
                if (co.Length > 1)
                {
                    co = ReduceList(co, i, saveLargerList: false);
                }
            }

            return Convert.ToInt32(oxy.First(), 2) * Convert.ToInt32(co.First(), 2);
        }

        private static string[] ReduceList(string[] input, int i, bool saveLargerList)
        {
            bool keepOnes;
            if (saveLargerList)
            {
                keepOnes = input.Count(x => x[i] == '0') <= input.Count() / 2;
            }
            else
            {
                keepOnes = input.Count(x => x[i] == '0') > input.Count() / 2;
            }

            if (keepOnes)
            {
                input = input.Where(x => x[i] == '1').ToArray();
            }
            else
            {
                input = input.Where(x => x[i] == '0').ToArray();
            }

            return input;
        }

        private static int Part1(string[] input)
        {
            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < input[0].Length; i++)
            {
                int ones = 0;
                int zeroes = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j][i] == '1')
                        ones++;
                    else
                        zeroes++;
                }
                epsilon += ones < zeroes ? "1" : "0";
                gamma += ones > zeroes ? "1" : "0";
            }

            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        }

        public int OldPart2(string[] input)
        {
            string oxygen = "";
            string co2 = "";

            for (int i = 0; i < input[0].Length; i++)
            {
                int oxygenOnes = 0;
                int oxygenZeroes = 0;
                int co2Ones = 0;
                int co2Zeroes = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j].StartsWith(oxygen))
                    {
                        if (input[j][i] == '1')
                            oxygenOnes++;
                        else
                            oxygenZeroes++;
                    }
                    if (input[j].StartsWith(co2))
                    {
                        if (input[j][i] == '1')
                            co2Ones++;
                        else
                            co2Zeroes++;
                    }
                }

                if (oxygenOnes + oxygenZeroes == 1)
                {
                    oxygen = input.First(x => x.StartsWith(oxygen));
                }
                else
                {
                    oxygen += oxygenOnes >= oxygenZeroes ? "1" : "0";
                }

                if (co2Ones + co2Zeroes == 1)
                {
                    co2 = input.First(x => x.StartsWith(co2));
                }
                else
                {
                    co2 += co2Ones < co2Zeroes ? "1" : "0";
                }
            }
            
            return Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2);
        }
    }
}
