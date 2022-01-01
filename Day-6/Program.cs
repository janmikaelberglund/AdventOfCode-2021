using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;

namespace Day_6
{
    internal class Program
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
        static void Main(string[] args)
        {
            string[] inputRaw = File.ReadAllLines(path);

            var split = inputRaw[0].Split(',');

            List<int> inputList = new List<int>(Array.ConvertAll(split, int.Parse));
            //List<int> inputList = new List<int>() { 1 }; // Use to try if 8 lists can hold one fish

            Stopwatch sw = new();
            BigInteger bigint = new();
            var count = 0;
            foreach (var fish in inputList)
            {
                sw.Start();
                count++;
                Console.WriteLine(count);
                bigint += part2(fish);
                Console.WriteLine(sw.Elapsed);
                sw.Stop();
                GC.Collect();
            }

            Console.WriteLine(part1(new(inputList)));
            Console.WriteLine(bigint);
        }
        private static int part1(List<int> input)
        {
            for (int i = 0; i < 80; i++)
            {
                int count = input.Count;
                for (int j = 0; j < count; j++)
                {
                    if (input[j] == 0)
                    {
                        input.Add(8);
                        input[j] = 6;
                    }
                    else
                    {
                        input[j]--;
                    }
                }
            }

            return input.Count;
        }

        private static BigInteger part2(int input)
        {
            List<List<int>> fishList = new();
            int numberOfLists = 8;
            for (int i = 0; i < numberOfLists; i++)
            {
                fishList.Add(new());
            }
            fishList[0].Add(input);

            int indexCounter = 0;
            for (int i = 256; i > 0; i--)
            {
                List<int> numberOfFishInEachList = new();
                for (int l = 0; l < numberOfLists; l++)
                {
                    numberOfFishInEachList.Add(fishList[l].Count);
                }

                int index0, index1, index2, index3, index4, index5, index6, index7, index8,
                    index9, index10, index11, index12, index13, index14, index15 = 0;
                index0 = index1 = index2 = index3 = index4 = index5 = index6 = index7 = index8 =
                    index9 = index10 = index11 = index12 = index13 = index14 = index15 = 0;
                int fishToAdd = 0;
                Parallel.For(0, numberOfLists, index =>
                {
                    var returnTuple = AddFish(new(fishList[index]), numberOfFishInEachList[index]);
                    fishList[index] = returnTuple.Item1;
                    DistributeNewFish(index, ref index0, ref index1, ref index2, ref index3, ref index4, ref index5, ref index6, ref index7, ref index8, ref index9, ref index10, ref index11, ref index12, ref index13, ref index14, ref index15, returnTuple);
                    GC.Collect();
                });

                fishToAdd = index0 + index1 + index2 + index3 + index4 + index5 + index6 + index7 + index8 + index9 + index10 + index11 + index12 + index13 + index14 + index15;
                indexCounter = AddNewFish(fishList, numberOfLists, indexCounter, fishToAdd);
            }

            BigInteger counter = 0;
            for (int i = 0; i < fishList.Count; i++)
            {
                counter += fishList[i].Count;
            }

            fishList = new();

            return counter;
        }

        private static void DistributeNewFish(int index, ref int index0, ref int index1, ref int index2, ref int index3, ref int index4, ref int index5, ref int index6, ref int index7, ref int index8, ref int index9, ref int index10, ref int index11, ref int index12, ref int index13, ref int index14, ref int index15, Tuple<List<int>, int> returnTuple)
        {
            switch (index)
            {
                case 0:
                    index1 = returnTuple.Item2;
                    break;
                case 1:
                    index2 = returnTuple.Item2;
                    break;
                case 2:
                    index3 = returnTuple.Item2;
                    break;
                case 3:
                    index4 = returnTuple.Item2;
                    break;
                case 4:
                    index5 = returnTuple.Item2;
                    break;
                case 5:
                    index6 = returnTuple.Item2;
                    break;
                case 6:
                    index7 = returnTuple.Item2;
                    break;
                case 7:
                    index8 = returnTuple.Item2;
                    break;
                case 8:
                    index9 = returnTuple.Item2;
                    break;
                case 9:
                    index10 = returnTuple.Item2;
                    break;
                case 10:
                    index11 = returnTuple.Item2;
                    break;
                case 11:
                    index12 = returnTuple.Item2;
                    break;
                case 12:
                    index13 = returnTuple.Item2;
                    break;
                case 13:
                    index14 = returnTuple.Item2;
                    break;
                case 14:
                    index15 = returnTuple.Item2;
                    break;
                case 15:
                    index0 = returnTuple.Item2;
                    break;
                default:
                    break;
            }
        }

        private static int AddNewFish(List<List<int>> fishList, int numberOfLists, int indexCounter, int fishToAdd)
        {
            int addCount = 0;
            bool addFish = true;
            while (addFish)
            {
                if (addCount < fishToAdd)
                {
                    if (indexCounter < numberOfLists - 1)
                    {
                        indexCounter++;
                    }
                    else
                    {
                        indexCounter = 0;
                    }
                    fishList[indexCounter].Add(8);
                }
                else
                {
                    addFish = false;
                }
                addCount++;
            }

            return indexCounter;
        }

        private static Tuple<List<int>, int> AddFish(List<int> partedFishList, int numberOfFish)
        {
            var fishToAdd = 0;
            for (int k = 0; k < numberOfFish; k++)
            {
                if (partedFishList[k] == 0)
                {
                    partedFishList[k] = 6;
                    fishToAdd++;
                }
                else
                {
                    partedFishList[k]--;
                }
            }

            return new Tuple<List<int>, int>(partedFishList, fishToAdd);
        }
    }
}
