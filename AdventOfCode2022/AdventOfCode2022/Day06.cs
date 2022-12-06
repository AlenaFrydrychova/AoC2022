using System.Reflection;

namespace AdventOfCode2022
{
    public class Day06
    {
        public void SolvePuzzle()
        {
            var input = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day06.txt")).ToCharArray().ToList();
            var listOfChars = new List<char>();
            var index = 0;
            foreach (var character in input)
            {
                listOfChars.Add(character);
                index++;
                if (CheckIfInList(listOfChars, character))
                {
                    Console.WriteLine(index);
                }
            }
        }

        private bool CheckIfInList(List<char> listOfChars, char character)
        {
            var lastChars = listOfChars.Skip(Math.Max(0, listOfChars.Count() - 14));
            return lastChars.Distinct().Count() == 14;
        }
    }
}
