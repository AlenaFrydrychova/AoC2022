using System.Reflection;

namespace AdventOfCode2022
{
    public class Day03
    {
        public void SolvePuzzle()
        {
            var input = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day03.txt"));
            var lines = input.Split(Environment.NewLine).Chunk(3);
            var commonChars = new List<char>();
            var alphabet = "abcdefghijklmnopqrstuvwxyz";

            foreach (var line in lines)
            {
                //var line1 = line.Substring(0, line.Length / 2);
                //var line2 = line.Substring(line.Length / 2, line.Length / 2);
                commonChars.Add(line[0].Intersect(line[1]).Intersect(line[2]).SingleOrDefault());
            }

            var sumPrioprity = 0;
              
            foreach (var character in commonChars)
            {
                var isUpper = Char.IsUpper(character);
                alphabet = isUpper ? alphabet.ToUpper() : alphabet.ToLower();
                sumPrioprity += isUpper ? alphabet.IndexOf(character) + 27 : alphabet.IndexOf(character) + 1;
            }

            Console.WriteLine(sumPrioprity);
        }
    }
}
