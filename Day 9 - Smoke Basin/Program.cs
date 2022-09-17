using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_9___Smoke_Basin
{
    internal class Program
    {
        internal static int[,] matrix;

        static void Main(string[] args)
        {
            List<string> inputs = File.ReadAllLines(@"..\..\input.txt").ToList();

            matrix = new int[inputs[0].Length, inputs.Count];
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    matrix[x, y] = Convert.ToInt32(Char.ToString(inputs[y][x]));
                }
            }

            int total = 0;
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    int nTop = -1, nLeft = -1, nRight = -1, nBottom = -1;

                    try { nLeft = matrix[x - 1, y]; } catch { }
                    try { nTop = matrix[x, y - 1]; } catch { }
                    try { nBottom = matrix[x, y + 1]; } catch { }
                    try { nRight = matrix[x + 1, y]; } catch { }

                    bool isMin = true;
                    if (nTop <= matrix[x, y] && nTop != -1)
                        isMin = false;
                    if (nLeft <= matrix[x, y] && nLeft != -1)
                        isMin = false;
                    if (nRight <= matrix[x, y] && nRight != -1)
                        isMin = false;
                    if (nBottom <= matrix[x, y] && nBottom != -1)
                        isMin = false;

                    if (isMin)
                        total += matrix[x, y] + 1;
                }
            }
            Console.WriteLine("part1 : " + total);

            total = 0;
            List<int> sizes = new List<int>();
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    int nTop = -1, nLeft = -1, nRight = -1, nBottom = -1;

                    try { nLeft = matrix[x - 1, y]; } catch { }
                    try { nTop = matrix[x, y - 1]; } catch { }
                    try { nBottom = matrix[x, y + 1]; } catch { }
                    try { nRight = matrix[x + 1, y]; } catch { }

                    bool isMin = true;
                    if (nTop <= matrix[x, y] && nTop != -1)
                        isMin = false;
                    if (nLeft <= matrix[x, y] && nLeft != -1)
                        isMin = false;
                    if (nRight <= matrix[x, y] && nRight != -1)
                        isMin = false;
                    if (nBottom <= matrix[x, y] && nBottom != -1)
                        isMin = false;

                    if (isMin)
                    {
                        total += matrix[x, y] + 1;

                        List<int[]> ints = new List<int[]>();
                        List<int[]> temp = new List<int[]>();
                        List<int[]> lastCo = new List<int[]> { new int[2] { x, y } };
                        List<int[]> _lastCo = new List<int[]>();
                        do
                        {
                            _lastCo.Clear();
                            for (int i = 0; i < lastCo.Count; i++)
                            {
                                temp = FindLowPointNext(lastCo[i]);

                                ints.AddRange(temp);
                                _lastCo.AddRange(temp);
                            }

                            lastCo.Clear();
                            lastCo = new List<int[]>(_lastCo);

                        } while (_lastCo.Any());

                        sizes.Add(ints.Count + 1);
                    }
                }
            }

            sizes.Sort();
            sizes.Reverse();

            Console.WriteLine("part2 : " + sizes[0] * sizes[1] * sizes[2]);
        }

        internal static List<int[]> FindLowPointNext(int[] co)
        {
            List<int[]> points = new List<int[]>();
            matrix[co[0], co[1]] = -1;

            try
            {
                if (matrix[co[0] - 1, co[1]] > matrix[co[0], co[1]] && matrix[co[0] - 1, co[1]] != 9)
                {
                    points.Add(new int[] { co[0] - 1, co[1] });
                    matrix[co[0] - 1, co[1]] = -1;
                }
            }
            catch { }

            try
            {
                if (matrix[co[0] + 1, co[1]] > matrix[co[0], co[1]] && matrix[co[0] + 1, co[1] ] != 9)
                {
                    points.Add(new int[] { co[0] + 1, co[1] });
                    matrix[co[0] + 1, co[1]] = -1;
                }
            }
            catch { }

            try
            {
                if (matrix[co[0], co[1] - 1] > matrix[co[0], co[1]] && matrix[co[0], co[1] - 1] != 9)
                {
                    points.Add(new int[] { co[0], co[1] - 1 });
                    matrix[co[0] , co[1] - 1] = -1;
                }
            }
            catch { }
            try
            {
                if (matrix[co[0], co[1] + 1] > matrix[co[0], co[1]] && matrix[co[0], co[1] + 1] != 9)
                {
                    points.Add(new int[] { co[0], co[1] + 1 });
                    matrix[co[0], co[1] + 1] = -1;
                }
            }
            catch { }

            return points;
        }
    }
}
