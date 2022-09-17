using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_13___Transparent_Origami
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://adventofcode.com/2021/day/13
            List<string> inputs = File.ReadAllLines(@"..\..\input.txt").ToList();

            bool[,] boards = new bool[1500, 1500];
            List<string> instructions = new List<string>();

            foreach (string input in inputs)
            {
                // Si c'est une coordonnée 
                if(input.Contains(","))
                {
                    // Ajoute au board
                    boards[Convert.ToInt32(input.Split(',')[1]), Convert.ToInt32(input.Split(',')[0])] = true;
                }
                else if(input.Contains("="))// Si c'est une instruction
                {
                    instructions.Add(input);
                }
            }

            int lastFoldPosX = -1;
            int lastFoldPosY = -1;
            for (int i = 0; i < instructions.Count; i++)
            {
                // Vertical line fold
                if (instructions[i].Contains("x"))
                {
                    int posToFold = Convert.ToInt32(instructions[i].Split('=')[1]);
                    lastFoldPosX = posToFold;

                    for (int x = 0; x < 1500; x++)
                    {
                        for (int y = 0; y < 1500; y++)
                        {
                            if (x > posToFold)
                            {
                                if (boards[y, x])
                                {
                                    boards[y, posToFold + (posToFold - x)] = true;

                                    // supprime le true pour la colonne plié (pas de doublon)
                                    boards[y, x] = false;
                                }
                            }
                        }
                    }
                }
                else // Horizontal line fold
                {
                    int posToFold = Convert.ToInt32(instructions[i].Split('=')[1]);
                    lastFoldPosY = posToFold;

                    for (int x = 0; x < 1500; x++)
                    {
                        for (int y = 0; y < 1500; y++)
                        {
                            if (y > posToFold)
                            {
                                if (boards[y, x])
                                {
                                    boards[posToFold + (posToFold - y),x ] = true;

                                    int a = posToFold - (posToFold - y);

                                    // supprime le true pour la colonne plié (pas de doublon)
                                    boards[y, x] = false;
                                }
                            }

                        }
                    }
                }


                // part1
                if (i == 0)
                {
                    int total = 0;

                    for (int x = 0; x < 1500; x++)                  
                        for (int y = 0; y < 1500; y++)                        
                            if (boards[y, x])                            
                                total++;
                                                                     
                    Console.WriteLine("part1 : " + total);
                }
            }

            // Affiche dans la console pour voir les 8 lettres dans le papier
            Console.WriteLine("part2 : ");

            List<string> lines = new List<string>();

            for (int x = 0; x < 1500; x++)
            {
                if (x < lastFoldPosX)
                {
                    lines.Add(String.Empty);
                    for (int y = 0; y < 1500; y++)
                    {
                        if(y < lastFoldPosY + 50) // I have no idea why "+50" but it works so don't touch it and don't ask questions about it
                            lines[lines.Count - 1] += (boards[x, y] == true ? "█" : " ");
                    }
                }
            }

            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}
