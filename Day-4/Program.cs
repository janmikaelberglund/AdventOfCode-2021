using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_4
{
    class Program
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
            List<int> numbers = new();
            List<List<int[]>> boards = new();
            var line = new int[5];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Replace("  ", " ");
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith(" "))
                {
                    input[i] = input[i].Substring(1);
                }
            }

            for (int i = 0; i < input.Length - 6; i++)
            {
                if (i == 0)
                {
                    numbers = Array.ConvertAll(input[i].Split(','), int.Parse).ToList();
                    continue;
                }
                if (string.IsNullOrEmpty(input[i]))
                {
                    continue;
                }
                List<int[]> newBoard = new();
                int j = 0;
                for (j = 0; j < 5; j++)
                {
                    var inputline = Array.ConvertAll(input[i + j].Split(new char[0]), int.Parse);
                    newBoard.Add(inputline);
                }
                boards.Add(newBoard);

                i += j;
            }

            var drawnNumbers = new List<int>();
            drawnNumbers.Add(numbers[0]);
            drawnNumbers.Add(numbers[1]);
            drawnNumbers.Add(numbers[2]);
            drawnNumbers.Add(numbers[3]);

            for (int i = 4; i < numbers.Count; i++)
            {
                drawnNumbers.Add(numbers[i]);
                for (int j = 0; j < boards.Count; j++)
                {
                    if (BoardBingo(boards[j], drawnNumbers))
                    {
                        if (boards.Count > 1)
                        {
                            boards.Remove(boards[j]);
                        }
                        else
                        {
                            return FinalScore(boards[j], drawnNumbers);
                        }
                    }
                }
            }

            return 0;
        }

        private static int part1(string[] input)
        {
            List<int> numbers = new();
            List<List<int[]>> boards = new();
            var line = new int[5];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Replace("  ", " ");
            }
            for (int i = 0;i < input.Length; i++)
            {
                if (input[i].StartsWith(" "))
                {
                    input[i] = input[i].Substring(1);
                }
            }

            for (int i = 0; i < input.Length - 6; i++)
            {
                if (i == 0)
                {
                    numbers = Array.ConvertAll(input[i].Split(','), int.Parse).ToList();
                    continue;
                }
                if (string.IsNullOrEmpty(input[i]))
                {
                    continue;
                }
                List<int[]> newBoard = new();
                int j = 0;
                for (j = 0; j < 5; j++)
                {
                    var inputline = Array.ConvertAll(input[i + j].Split(new char[0]), int.Parse);
                    newBoard.Add(inputline);
                }
                boards.Add(newBoard);

                i += j;
            }

            var drawnNumbers = new List<int>();
            drawnNumbers.Add(numbers[0]);
            drawnNumbers.Add(numbers[1]);
            drawnNumbers.Add(numbers[2]);
            drawnNumbers.Add(numbers[3]);
            for (int i = 4; i < numbers.Count; i++)
            {
                drawnNumbers.Add(numbers[i]);
                foreach (var board in boards)
                {
                    if (BoardBingo(board, drawnNumbers))
                    {
                        return FinalScore(board, drawnNumbers);
                    }
                }
            }

            return 0;
        }

        private static int FinalScore(List<int[]> board, List<int> numbers)
        {
            List<int> unmarkedNumbers = new List<int>();

            foreach (var row in board)
            {
                foreach (var number in row)
                {
                    if (!numbers.Contains(number))
                    {
                        unmarkedNumbers.Add(number);
                    }
                }
            }

            var sum = unmarkedNumbers.Sum();
            var fintal = numbers.Last();

            return unmarkedNumbers.Sum() * numbers.Last();
        }

        private static bool BoardBingo(List<int[]> board, List<int> drawnNumbers)
        {
            int count;
            for (int i = 0; i < 5; i++)
            {
                count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (drawnNumbers.Contains(board[i][j]))
                    {
                        count++;
                    }
                }
                if (count == 5)
                    return true;

                count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (drawnNumbers.Contains(board[j][i]))
                    {
                        count++;
                    }
                }
                if (count == 5)
                    return true;
            }
            return false;
        }
    }
}
