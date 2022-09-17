using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_10___Syntax_Scoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://adventofcode.com/2021/day/10
            List<List<char>> inputs = File.ReadAllLines(@"..\..\input.txt").ToList().ConvertAll(x => x.ToCharArray().ToList());

            List<char[]> includers = new List<char[]>()
            {
                new char[]{'[',']'},
                new char[]{'{','}'},
                new char[]{'(',')'},
                new char[]{'<','>'}
            };

            int totalPart1 = 0;
            List<ulong> totalsPart2 = new List<ulong>();

            for (int index = 0; index < inputs.Count; index++)
            {
                List<char> input = inputs[index];
                bool isIncomplet = true;
                string actualProcess = string.Empty;

                for (int i = 0; i < input.Count; i++)
                {
                    actualProcess += input[i];

                    if (i > 0)
                    {
                        char[] includer = new char[2];
                        // if it is a closing char
                        if (includers.Any(x =>
                        {
                            includer = x;
                            if (x[1] == actualProcess[actualProcess.Length - 1])
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }))
                        {
                            // if it correspond the good one
                            if (actualProcess[actualProcess.Length - 2] == includer[0])
                            {
                                // good closing char
                                actualProcess = actualProcess.Remove(actualProcess.Length - 2);
                            }
                            else
                            {
                                isIncomplet = false;

                                actualProcess = actualProcess.Remove(actualProcess.Length - 2);

                                // bad closing char
                                switch (includer[1])
                                {
                                    case '}':
                                        totalPart1 += 1197;
                                        break;
                                    case ')':
                                        totalPart1 += 3;
                                        break;
                                    case ']':
                                        totalPart1 += 57;
                                        break;
                                    case '>':
                                        totalPart1 += 25137;
                                        break;
                                }
                            }
                        }
                    }
                }

                // part2
                if(isIncomplet)
                {
                    // delete the good includers 
                    int lastWhileLoop;

                    do
                    {
                        lastWhileLoop = inputs[index].Count;

                        inputs[index] = String.Join(string.Empty, inputs[index])
                            .Replace("{}", string.Empty)
                            .Replace("<>", string.Empty)
                            .Replace("[]", string.Empty)
                            .Replace("()", string.Empty).ToCharArray().ToList();

                    } while (inputs[index].Count != lastWhileLoop);

                    // add the good includers so the lign complet
                    ulong total = 0;
                    while (inputs[index].Count > 0)
                    {
                        total *= 5;

                        switch (inputs[index].Last())
                        {
                            case '{':
                                total += 3;
                                break;
                            case '(':
                                total += 1;
                                break;
                            case '[':
                                total += 2;
                                break;
                            case '<':
                                total += 4;
                                break;
                        }

                        inputs[index].RemoveAt(inputs[index].Count - 1);
                    }

                    totalsPart2.Add(total);
                }
            }

            Console.WriteLine("part1 : " + totalPart1);

            totalsPart2.Sort();
            Console.WriteLine("part2 : " + totalsPart2[(totalsPart2.Count) / 2]);
        }
    }
}
