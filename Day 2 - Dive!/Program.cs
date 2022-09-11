using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2___Dive_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://adventofcode.com/2021/day/2
            List<string> movement = File.ReadAllLines(@"..\..\input.txt").ToList();

            int depth = 0;
            int forward = 0;

            movement.ForEach(x =>
            {
                int hm = Convert.ToInt16(x.Split(' ')[1]);
                switch (x.Split(' ')[0])
                {
                    case "forward":
                        forward += hm;
                        break;
                    case "down":
                        depth += hm;
                        break;
                    case "up":
                        depth -= hm;
                        break;
                }
            });

            Console.WriteLine("part1: " + depth * forward);

            int aim = 0;
            depth = 0;
            forward = 0;

            movement.ForEach(x =>
            {
                int hm = Convert.ToInt16(x.Split(' ')[1]);
                switch (x.Split(' ')[0])
                {
                    case "forward":
                        forward += hm;
                        depth += hm * aim;
                        break;
                    case "down":
                        aim += hm;
                        break;
                    case "up":
                        aim -= hm;
                        break;
                }
            });

            Console.WriteLine("part2: " + depth * forward);
        }
    }
}
