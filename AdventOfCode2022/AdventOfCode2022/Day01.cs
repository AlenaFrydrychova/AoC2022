using System.Reflection;

namespace AdventOfCode2022
{
    public class Day01
    {
        public void SolvePuzzle()
        {
            var input = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day01.txt"));
            var top3 = input.Split("\r\n\r\n")
                                .Select(
                                    x => x.Split("\r\n")
                                .Sum(x => Convert.ToInt32(x)))
                                .ToList()
                                .OrderByDescending(x => x)
                                .Take(3);

            Console.WriteLine($"Elf carrying the most calories has {top3.First()} cal in total.");
            Console.WriteLine($"Top 3 elves have {top3.Sum()} calories in total.");
        }
    }
}
