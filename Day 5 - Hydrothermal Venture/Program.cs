using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5___Hydrothermal_Venture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://adventofcode.com/2021/day/5
            List<string[]> inputs = File.ReadAllLines(@"..\..\input.txt").ToList().ConvertAll(x =>
            {
                return x.Split(new string[] { " -> " }, StringSplitOptions.None);           
            });

            // remove all non-vertical or non-horizontal lines
            // x1 = x2 or y1 = y2 = vertical/horizontal
            inputs.RemoveAll(x =>
            {
                if (x[0].Split(',')[0] == x[1].Split(',')[0]
                ||
                x[0].Split(',')[1] == x[1].Split(',')[1])
                    return false;
                else
                    return true;
            });

            int[,] board = new int[1000, 1000];
            for (int x = 0; x < 1000; x++)            
                for (int y = 0; y < 1000; y++)                
                    board[x, y] = 0;
                
            

            inputs.ForEach(input =>
            {
                int x1 = Convert.ToInt32(input[0].Split(',')[0]);
                int y1 = Convert.ToInt32(input[0].Split(',')[1]);

                int x2 = Convert.ToInt32(input[1].Split(',')[0]);
                int y2 = Convert.ToInt32(input[1].Split(',')[1]);

                // trace les lignes
                if(x1 == x2) // ligne verticales
                {
                    int firstY = y2 < y1 ? y2 : y1; // le plus petit des 2
                    int secondY = y2 < y1 ? y1 : y2; // le plus grand des 2

                    for (int i = firstY; i < secondY + 1; i++)
                    {
                        board[i, x1] += 1;
                    }
                }
                else // ligne horizontal
                {
                    int firstX = x2 < x1 ? x2 : x1; // le plus petit des 2
                    int secondX = x2 < x1 ? x1 : x2; // le plus grand des 2

                    for (int i = firstX; i < secondX + 1; i++)
                    {
                        board[y1, i] += 1;
                    }
                }
            });

            int atLeast2lines = 0;

            for (int x = 0; x < 1000; x++)
                for (int y = 0; y < 1000; y++)
                    if(board[x, y] >= 2)
                        atLeast2lines++;

            Console.WriteLine("part1 : " + atLeast2lines);
        }
    }
}
