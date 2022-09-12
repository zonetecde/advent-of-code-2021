using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4___Giant_Squid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://adventofcode.com/2021/day/4
            List<string> inputs = File.ReadAllLines(@"..\..\input.txt").ToList();

            // l1. bingo's number
            List<int> bingosNumber = inputs[0].Split(',').Select(x => int.Parse(x)).ToList();

            // permet de faire fonctionner l'algorithme de récup des boards
            inputs = inputs.ConvertAll(x => { return x.Replace("  ", " "); }).ConvertAll(y =>
            {
                if (y.StartsWith(" "))
                    return y.Remove(0, 1);
                else return y;
            });

            List<int[,]> boards = new List<int[,]>();

            for (int i = 2; i < inputs.Count; i += 6)
            {
                boards.Add(new int[5, 5]);
                for (int y = 0; y < 5; y++)               
                    for (int x = 0; x < 5; x++)                
                        boards.Last()[y, x] = Convert.ToInt32(inputs[i + y].Split(' ')[x]);                                
            }

            List<int> boardWhoWon = new List<int>();

            foreach (int number in bingosNumber)
            {
                boards.ForEach(board =>
                {
                    for (int y = 0; y < 5; y++)
                        for (int x = 0; x < 5; x++)
                            if (board[y, x] == number)
                            {
                                board[y, x] = -1;

                                // si la colonne ou la ligne n'a que des -1 alors c'est bingo
                                int minusOneInRow = 0;
                                int minusOneInColumn = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    if(board[i, x] == -1)
                                    {
                                        minusOneInColumn++;
                                    }
                                    if(board[y, i] == -1)
                                    {
                                        minusOneInRow++;
                                    }
                                }

                                // bingo si == 5
                                if(minusOneInRow == 5 || minusOneInColumn == 5)
                                {
                                    // somme de tout les nombres unmarked dans le tableau
                                    int finalScore = 0;
                                    for (int x2 = 0; x2 < 5; x2++)
                                    {
                                        for (int y2 = 0; y2 < 5; y2++)
                                        {
                                            if (board[x2, y2] != -1)
                                                finalScore += board[x2, y2];
                                        }
                                    }

                                    // multiplier par le dernier nombre
                                    finalScore *= number;

                                    // pour pas qu'un même tableau win 2 fois
                                    if (boardWhoWon.Contains(boards.IndexOf(board)))
                                        return;
                                    
                                    boardWhoWon.Add(boards.IndexOf(board));

                                    if (nbOfWin == 1)
                                        Console.WriteLine("part1 : " + finalScore);
                                    if (boardWhoWon.Count == boards.Count)
                                        Console.WriteLine("part2 : " + finalScore);                                   

                                    return;
                                }
                            }
                });
            }
        }
    }
}
