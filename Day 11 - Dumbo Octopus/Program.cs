using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11___Dumbo_Octopus
{
    internal class Program
    {
        private const int BOARD_SIZE = 10;

        static void Main(string[] args)
        {
            // https://adventofcode.com/2021/day/11
            List<string> inputs = File.ReadAllLines(@"..\..\input.txt").ToList();
            int[,] boards = new int[BOARD_SIZE, BOARD_SIZE];

            for (int x = 0; x < BOARD_SIZE; x++)
            {
                for (int y = 0; y < BOARD_SIZE; y++)
                {
                    boards[x, y] = Convert.ToInt16(Char.ToString(inputs[x][y]));
                }
            }

            int total = 0;
            for (int step = 1; step <= 10000; step++)
            {
                int part2 = 0;

                // increase every octopus to one
                for (int x = 0; x < BOARD_SIZE; x++)
                {
                    for (int y = 0; y < BOARD_SIZE; y++)
                    {
                        boards[y, x] += 1;
                    }
                }

                //  boom every 9
                int[,] temp;
                List<int[]> stayZero = new List<int[]>();
                do
                {
                    temp = boards.Clone() as int[,];

                    for (int x = 0; x < BOARD_SIZE; x++)
                    {
                        for (int y = 0; y < BOARD_SIZE; y++)
                        {
                            if (temp[y, x] >= 10)
                            {
                                boards[y, x] = 0;
                                stayZero.Add(new int[2] { y, x });

                                total++;
                                part2++;

                                boards = increase(boards, y - 1, x - 1);
                                boards = increase(boards, y - 1, x);
                                boards = increase(boards, y, x - 1);
                                boards = increase(boards, y + 1, x + 1);
                                boards = increase(boards, y + 1, x);
                                boards = increase(boards, y, x + 1);
                                boards = increase(boards, y + 1, x - 1);
                                boards = increase(boards, y - 1, x + 1);
                            }
                        }
                    }

                    foreach (int[] co in stayZero)
                        boards[co[0], co[1]] = 0;

                    if (part2 == BOARD_SIZE * BOARD_SIZE)
                    {
                        Console.WriteLine("part2 : " + step);
                        goto END;
                    }

                } while (!ContentEquals(temp, boards));


                if(step == 100)
                    Console.WriteLine("part1 : " + total);
            }

        END:;
        }

        public static bool ContentEquals<T>(T[,] arr, T[,] other) where T : IComparable
        {
            if (arr.GetLength(0) != other.GetLength(0) ||
                arr.GetLength(1) != other.GetLength(1))
                return false;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j].CompareTo(other[i, j]) != 0)
                        return false;
            return true;
        }

        private static int[,] increase(int[,] boards, int v1, int v2)
        {
            try
            {
                boards[v1, v2] += 1;
            }
            catch
            {
            }

            return boards;
        }
    }
}
