using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8___Seven_Segment_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputs = File.ReadAllLines(@"..\..\input.txt").ToList();
            List<string> inputsPart1 = new List<string>();

            inputs.ForEach(x =>
            {
                inputsPart1.AddRange(x.Split(new string[] { " | " }, StringSplitOptions.None)[1].Split(' ').ToList()) ;
            });
            
            // part1 : focus only on 1, 4, 7 & 8 
            int nbOfUniqueDigit = inputsPart1.Count(x => x.Length == 2 || x.Length == 4 || x.Length == 3 || x.Length == 7);

            Console.WriteLine("part1 : " + nbOfUniqueDigit);

            // part2
            foreach(string input in inputs)
            {
                string theDigits = input.Split(new string[] { " | " }, StringSplitOptions.None)[0];
                string code = input.Split(new string[] { " | " }, StringSplitOptions.None)[1];


            }




            List<string> inputsPart12 = File.ReadAllLines(@"..\..\input.txt").ToList();



            int total = 0;
            inputsPart12.ForEach(input =>
            {
                //string[] last4strings = input.Split(new string[] { " | " }, StringSplitOptions.None)[1].Split(' ');

                //List<t> occurences = new List<t>();

                //foreach (char lettre in "abcdefg".ToCharArray())
                //{
                //    string str = String.Join("", last4strings);
                //    occurences.Add (new t(lettre, str.Count(x => x == lettre)));
                //}





            });
        }
    }

    class t
    {
        char lettre;
        int occurence;

        public t(char lettre, int occurence)
        {
            this.lettre = lettre;
            this.occurence = occurence;
        }
    }
}
