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


            Console.WriteLine(part1(new(inputList)));
            Console.WriteLine(part2(new(inputList)));
        }

        private static int part2(List<List<int>> input)
        {
            input.RemoveAll(x => IsNotVerticalNorHorizontal(x) && !isDiagonal(x));
            var arrayen = new int[999, 999];

            foreach (var row in input)
            {
                if (row[0] == row[2])
                {
                    if (row[1] > row[3])
                    {
                        for (int i = 0; i <= row[1] - row[3]; i++)
                        {
                            arrayen[row[0], row[3] + i]++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= row[3] - row[1]; i++)
                        {
                            arrayen[row[0], row[1] + i]++;
                        }
                    }
                }
                if (row[1] == row[3])
                {
                    if (row[0] > row[2])
                    {
                        for (int i = 0; i <= row[0] - row[2]; i++)
                        {
                            arrayen[row[2] + i, row[1]]++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= row[2] - row[0]; i++)
                        {
                            arrayen[row[0] + i, row[1]]++;
                        }
                    }
                }

                if (isDiagonal(row))
                {
                    int diff = row[0] - row[2];
                    if (diff < 0)
                    {
                        diff = row[1] - row[3];
                        if (diff < 0)
                        {
                            for (int i = 0; i <= Math.Abs(diff); i++)
                            {
                                arrayen[row[0] + i, row[1] + i]++;
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= Math.Abs(diff); i++)
                            {
                                arrayen[row[0] + i, row[1] - i]++;
                            }
                        }
                    }
                    else
                    {
                        diff = row[1] - row[3];
                        if (diff < 0)
                        {
                            for (int i = 0; i <= Math.Abs(diff); i++)
                            {
                                arrayen[row[0] - i, row[1] + i]++;
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= Math.Abs(diff); i++)
                            {
                                arrayen[row[0] - i, row[1] - i]++;
                            }
                        }
                    }
                }
            }

            var counter = 0;
            foreach (var number in arrayen)
            {
                if (number > 1)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static bool isDiagonal(List<int> x)
        {
            if (Math.Abs(x[0] - x[2]) == Math.Abs(x[1] - x[3]))
            {
                return true;
            }

            return false;
        }

        private static int part1(List<List<int>> input)
        {
            input.RemoveAll(x => IsNotVerticalNorHorizontal(x));

            var arrayen = new int[999, 999];

            foreach (var row in input)
            {
                if (row[0] == row[2])
                {
                    if (row[1] > row[3])
                    {
                        for (int i = 0; i <= row[1] - row[3]; i++)
                        {
                            arrayen[row[0], row[3] + i]++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= row[3] - row[1]; i++)
                        {
                            arrayen[row[0], row[1] + i]++;
                        }
                    }
                }
                if (row[1] == row[3])
                {
                    if (row[0] > row[2])
                    {
                        for (int i = 0; i <= row[0] - row[2]; i++)
                        {
                            arrayen[row[2] + i, row[1]]++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= row[2] - row[0]; i++)
                        {
                            arrayen[row[0] + i, row[1]]++;
                        }
                    }
                }
            }

            var counter = 0;
            foreach (var number in arrayen)
            {
                if (number > 1)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static bool IsNotVerticalNorHorizontal(List<int> x)
        {
            if (x[0] != x[2] && x[1] != x[3])
            {
                return true;
            }
            else
            {
                return false;
            }
            //return x[0] != x[2] && x[1] != x[3];
        }
    }
}
