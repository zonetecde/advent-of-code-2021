using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3___Binary_Diagnostic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://adventofcode.com/2021/day/3
            List<string> binarys = File.ReadAllLines(@"..\..\input.txt").ToList();

            string gamma = string.Empty;
            string epsilon = string.Empty;

            for (int i = 0; i < binarys[0].Length; i++)
            {
                if (binarys.Count(x =>
                {
                    return x[i] == '0' ? true : false;
                }) > binarys.Count(x =>
                {
                    return x[i] == '1' ? true : false;
                })) // plus de 0 que de 1
                {
                    gamma += "0";
                    epsilon += "1";
                }
                else
                {
                    gamma += "1";
                    epsilon += "0";
                }
            }

            Console.WriteLine("part1 : " + Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));

            string oxygen = Algo(new List<string>(binarys), 0, '0', '1');
            string co2 = Algo(new List<string>(binarys), 0, '1', '0');

            Console.WriteLine("part2 : " + Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2));
        }

        private static string Algo(List<string> binarys, int index, char firstPredicate, char secondPredicate)
        {
            int nbThatHave0 = binarys.Count(x =>
            {
                return x[index] == '0' ? true : false;
            });
            int nbThatHave1 = binarys.Count(x =>
            {
                return x[index] == '1' ? true : false;
            });


            if (nbThatHave0 > nbThatHave1) // plus de 0 que de 1 
            {
                binarys.RemoveAll(x => x[index] == secondPredicate);

                if(binarys.Count > 1)
                    return Algo(binarys, index + 1, firstPredicate, secondPredicate);
            }
            else if (nbThatHave0 < nbThatHave1) // plus de 1 que de 0
            {
                binarys.RemoveAll(x => x[index] == firstPredicate);

                if (binarys.Count > 1)
                    return Algo(binarys, index + 1, firstPredicate, secondPredicate);
            }
            else // 1 == 0
            {
                binarys.RemoveAll(x => x[index] == firstPredicate);

                if (binarys.Count > 1)
                    return Algo(binarys, index + 1, firstPredicate, secondPredicate);
                else
                    return binarys.First();
            }

            return binarys.First();
        }
    }
}
