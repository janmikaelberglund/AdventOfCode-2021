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
        public static string path = Path.Combine(Environment.CurrentDirectory, "example.txt");
        static void Main(string[] args)
        {
            string[] inputRaw = File.ReadAllLines(path);

            var split = inputRaw[0].Split(',');

            List<int> inputList = new List<int>(Array.ConvertAll(split, int.Parse));
            //List<int> inputList = new List<int>() { 1};

            BigInteger bigint = new();
            var count = 0;
            foreach (var fish in inputList)
            {
                count++;
                Console.WriteLine(count);
                bigint += part2(fish);
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
            int numberOfLists = 16; //Try 8 to so only one list per thread, thus only one method per thread runs
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

                int index0,index1,index2,index3,index4,index5,index6,index7,index8,
                    index9,index10,index11,index12,index13,index14,index15 = 0;
                index0 = index1 = index2 = index3 = index4 = index5 = index6 = index7 = index8 =
                    index9 = index10 = index11 = index12 = index13 = index14 = index15 = 0;
                int fishToAdd = 0;
                Parallel.For(0, numberOfLists, index =>
                {
                    var returnTuple = AddFish(new(fishList[index]), numberOfFishInEachList[index]);
                    fishList[index] = returnTuple.Item1;
                    switch (index)
                    {
                        case 0:
                            index0 = returnTuple.Item2;
                            break;
                        case 1:
                            index1 = returnTuple.Item2;
                            break;
                        case 2:
                            index2 = returnTuple.Item2;
                            break;
                        case 3:
                            index3 = returnTuple.Item2;
                            break;
                        case 4:
                            index4 = returnTuple.Item2;
                            break;
                        case 5:
                            index5 = returnTuple.Item2;
                            break;
                        case 6:
                            index6 = returnTuple.Item2;
                            break;
                        case 7:
                            index7 = returnTuple.Item2;
                            break;
                        case 8:
                            index8 = returnTuple.Item2;
                            break;
                        case 9:
                            index9 = returnTuple.Item2;
                            break;
                        case 10:
                            index10 = returnTuple.Item2;
                            break;
                        case 11:
                            index11 = returnTuple.Item2;
                            break;
                        case 12:
                            index12 = returnTuple.Item2;
                            break;
                        case 13:
                            index13 = returnTuple.Item2;
                            break;
                        case 14:
                            index14 = returnTuple.Item2;
                            break;
                        case 15:
                            index15 = returnTuple.Item2;
                            break;
                        default:
                            break;
                    }
                });

                fishToAdd = index0 + index1 + index2 + index3 + index4 + index5 + index6 + index7 + index8 + index9 + index10 + index11 + index12 + index13 + index14 + index15;

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


                //for (int j = 0; j < numberOfLists - 1; j++)
                //{

                //    AddFish(numberOfFishInEachList, j);
                //}
            }

            BigInteger counter = 0;
            for (int i = 0; i < fishList.Count; i++)
            {
                counter += fishList[i].Count;
            }

            fishList = new();
            
            return counter;
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
