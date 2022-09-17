using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14___Extended_Polymerization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://adventofcode.com/2021/day/14

            List<string> inputs = File.ReadAllLines(@"..\..\input.txt").ToList();

            // xy -> z
            List<string[]> criteres = new List<string[]>();

            // phrase base
            string output = inputs[0];

            // i = 2 car les chaînes commences à ligne 3
            // ajoute les critères
            for (int i = 2; i < inputs.Count; i++)
            {
                criteres.Add(new string[2]
                {
                    inputs[i].Split(new string[] {" -> "}, StringSplitOptions.None)[0],
                    inputs[i].Split(new string[] {" -> "}, StringSplitOptions.None)[1]
                });
            }

            // t[0] = indexToAdd, t[1] = letterToAdd
            List<string[]> indexes = new List<string[]>();
            for (int step = 0; step < 40; step++)
            {
                // Applique les critères
                foreach (string[] critere in criteres)
                {
                    // Ajoute dans indexes tous les endroits ou le caractère doit être ajouté
                    for (int index = 0; ; index += 1)
                    {
                        index = output.IndexOf(critere[0], index);
                        if (index != -1)
                            indexes.Add(new string[] { (index + 1).ToString(), critere[1] });
                        else
                            break;
                    }
                }

                // Ajoute les caractères au output
                int decallage = 0;
                indexes = indexes.OrderBy(x => Convert.ToInt32(x[0])).ToList();
                foreach (string[] index in indexes)
                {
                    output = output.Insert(Convert.ToInt32(index[0]) + decallage, index[1]);
                    decallage++;
                }

                indexes.Clear();

                Console.WriteLine(step);
            }

            // quantity of the most common element and subtract the quantity of the least common element
            var temp = output.ToCharArray().ToList();
            temp = temp.OrderBy(x => temp.Count(y => y == x)).ToList();
            ulong part1Result = (ulong)temp.Count(x => x == temp.Last()) - (ulong)temp.Count(x => x == temp.First());

            Console.WriteLine("part1 : " + part1Result);
        }
    }
}
