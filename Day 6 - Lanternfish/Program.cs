using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6___Lanternfish
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://adventofcode.com/2021/day/6
            List<long> inputs = File.ReadAllText(@"..\..\input.txt").Split(',').Select(x => long.Parse(x)).ToList();
            //inputs = "3,4,3,1,2".Split(',').Select(x => long.Parse(x)).ToList();

            List<long> nbOfX = new List<long>();
            List<long> nbDone = new List<long>();

            inputs.Sort();
            for (long i = inputs.First(); i <= inputs.Last(); i++)
            {
                //  groups all the same numbers into one and adds their real number into nbOfX
                if (!nbDone.Contains(i))
                    nbOfX.Add(inputs.Count(x => x == i));
                nbDone.Add(i);
            }

            inputs = inputs.Distinct().ToList(); // remove all the duplicate

            // inputs = [ 1, 2, 3, 4 ] -> value
            // nbOfX  = [ 2, 1, 1, 3 ] -> coefficient  
            // -> there is two "1", one "2", one "3" and three "4"

            Console.WriteLine("\n\npart1 : " + CountLanternfish(inputs, nbOfX, 80));
            Console.WriteLine("\n\npart2 : " + CountLanternfish(inputs, nbOfX, 256));
        }

        private static long CountLanternfish(List<long> inputs, List<long> nbOfX, long days)
        {
            for (long day = 1; day <= days; day++) // for each day
            {
                long eightToAdd = 0; // eight to add at the end of the list nbOfX. One 8 only will be added to the inputs

                for (int i = 0; i < inputs.Count; i++) // for each input
                {
                    inputs[i] -= 1; // we substract the input by one

                    if (inputs[i] == -1) // if it is == -1 we need to create a new 8 at the end of the list
                    {
                        inputs[i] = 6; // change the actual number to 8

                        eightToAdd += nbOfX[i]; // there were maybe four "-1", so we add four eight
                    }
                }

                if (eightToAdd > 0)
                {
                    inputs.Add(8); // add ONE eight
                    nbOfX.Add(eightToAdd); // say that there is x eight (but not one)
                }
            }

            long total = 0; 
            for (int i = 0; i < nbOfX.Count; i++) // calcul the total of input
            {
                total += nbOfX[i]; 
            }

            return total;
        }
    }
}
