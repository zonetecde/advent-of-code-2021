using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7___The_Treachery_of_Whales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://adventofcode.com/2021/day/7
            List<int> inputs = File.ReadAllText(@"..\..\input.txt").Split(',').Select(x => int.Parse(x)).ToList();
            //inputs = "16,1,2,0,4,2,7,1,2,14".Split(',').Select(x => int.Parse(x)).ToList();

            int maxPos = inputs.Max();
            int minPos = inputs.Min();

            List<int> possibleMovement = new List<int>();

            for (int pos = minPos; pos <= maxPos; pos++)
            {
                int totalFuel = 0;

                for (int input = 0; input < inputs.Count; input++)
                {
                    totalFuel += System.Math.Abs(inputs[input] - pos);
                }

                possibleMovement.Add(totalFuel);
            }

            Console.WriteLine("part1 : " + possibleMovement.Min());

            possibleMovement.Clear();

            for (int pos = minPos; pos <= maxPos; pos++)
            {
                int totalFuel = 0;

                for (int input = 0; input < inputs.Count; input++)
                {
                    int distance = Math.Abs(inputs[input] - pos);
                    totalFuel += Convert.ToInt32((Math.Pow(distance, 2) + distance) / 2);
                }

                possibleMovement.Add(totalFuel);
            }

            Console.WriteLine("part2 : " + possibleMovement.Min());
        }
    }
}
