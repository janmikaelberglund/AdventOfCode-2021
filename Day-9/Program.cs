using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_9
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "example.txt");
        static void Main(string[] args)
        {
            var rawInput = File.ReadAllLines(path);

            List<List<int>> input = new();
            foreach (var item in rawInput)
            {
                string[] temp = Array.ConvertAll(item.ToCharArray(), char.ToString);
                input.Add(new(Array.ConvertAll(temp, int.Parse)));
            }

            List<List<int[]>> part2List = new();

                foreach (var innerList in input)
                {
                    List<int[]> part2inner = new();
                    foreach (var number in innerList)
                    {
                        if (number == 9)
                        {
                            part2inner.Add(new int[] { number, 1 });
                        }
                        else
                        {
                            part2inner.Add(new int[] { number, 0 });
                        }
                    }
                    part2List.Add(part2inner);
                }


            Console.WriteLine(part1(new(input)));
            Console.WriteLine(part2(part2List));
        }
        private static int part1(List<List<int>> input)
        {
            input = FormatInput(input, 99);

            List<int> test = new();

            var counter = 0;
            for (int i = 1; i < input.Count - 1; i++)
            {
                for (int j = 1; j < input[i].Count - 1; j++)
                {
                    bool conditionLeft = input[i][j] < input[i][j - 1];
                    bool conditionRight = input[i][j] < input[i][j + 1];
                    bool conditionUp = input[i][j] < input[i - 1][j];
                    bool conditionDown = input[i][j] < input[i + 1][j];

                    bool condition = conditionLeft && conditionRight && conditionUp && conditionDown;
                    if (condition)
                    {
                        counter += input[i][j] + 1;
                    }
                }
            }

            return counter;
        }

        private static List<List<int>> FormatInput(List<List<int>> input, int border)
        {
            List<int> temp = new();
            input.Insert(0, temp);
            input.Insert(input.Count, temp);

            for (int i = 0; i < input.Count; i++)
            {
                input.First().Add(border);
                input.Last().Add(border);
            }

            for (int i = 0; i < input.Count; i++)
            {
                input[i].Insert(0, border);
                input[i].Insert(input[i].Count, border);
            }

            return input;
        }
        private static List<List<int[]>> FormatInput(List<List<int[]>> input, int[] border)
        {
            List<int[]> temp = new();
            input.Insert(0, temp);
            input.Insert(input.Count, temp);

            var inputCount = input.Count;
            for (int i = 0; i < inputCount -1; i++)
            {
                input.First().Add(border);
                input.Last().Add(border);
            }

            for (int i = 1; i < inputCount -1; i++)
            {
                input[i].Insert(0, border);
                input[i].Insert(input[i].Count, border);
            }

            return input;
        }

        private static int part2(List<List<int[]>> heightMap)
        {
            List<List<int[]>> basins = FindAllBasins(heightMap).OrderBy(x => x.Count()).ToList();


            return basins[0].Count() * basins[1].Count() * basins[2].Count();
        }

        private static List<List<int[]>> FindAllBasins(List<List<int[]>> heightMap)
        {
            int[] border = new int[] { 9, 1};
            heightMap = FormatInput(heightMap, border);
            List<List<int[]>> results = new();
            var iCount = heightMap.Count;
            var jCount = heightMap[0].Count;
            
            for (int i = 0; i < iCount;i++)
            {
                for (int j = 0; j < jCount; j++)
                {
                    //if (heightMap[])
                    //{

                    //}
                }
            }

            return results;
        }

        private static List<int[]> FindBasin(List<List<int[]>> heightMap, int i, int j)
        {
            List<int[]> basin = new();





            return basin;
        }
    }
}