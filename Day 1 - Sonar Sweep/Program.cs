using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1___Sonar_Sweep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://adventofcode.com/2021/day/1
            List<int> numbers = File.ReadAllLines(@"..\..\input.txt").Select(int.Parse).ToList();

            int i = -2;

            Console.WriteLine("part1 : " + numbers.FindAll(x =>
                {
                    i++;

                    if (i < 0)               
                        return false;              
                    else if (x > numbers[i])                
                        return true;                
                    else            
                        return false;
                
                }).Count()
            );

            i = -1;

            Console.WriteLine("part2 : " + numbers.FindAll(x =>
                {
                    i++;

                    try
                    {
                        if (i < 0)
                            return false;
                        else if (x + numbers[i + 1] + numbers[i + 2] < numbers[i + 1] + numbers[i + 2] + numbers[i + 3])
                            return true;
                        else
                            return false;
                    }
                    catch
                    {
                        return false;
                    }

                }).Count()
            );
        }
    }
}
