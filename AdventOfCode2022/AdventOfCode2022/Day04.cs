using System.Reflection;

namespace AdventOfCode2022
{
    public class Day04
    {
        public void SolvePuzzle()
        {
            var input = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day04.txt"));
            var pairs = input.Split(Environment.NewLine).Select(line => line.Split(","));
            var commonSectionsPairCount = 0;
            foreach (var pair in pairs)
            {
                if (FindCommonSections(pair))
                {
                    commonSectionsPairCount++;
                }
            }
            Console.WriteLine(commonSectionsPairCount);
        }

        private bool FindCommonSections(string[] pair)
        {
            var elf1 = pair[0].Split("-");
            var elf1Range = new List<int> { Int32.Parse(elf1[0]), Int32.Parse(elf1[1]) };
            var elf2 = pair[1].Split("-");
            var elf2Range = new List<int> { Int32.Parse(elf2[0]), Int32.Parse(elf2[1]) };

            return CompareRanges(elf1Range, elf2Range);
        }

        private bool CompareRanges(List<int> elf1Range, List<int> elf2Range)
        {
            if (elf2Range.First() >= elf1Range.First() && elf2Range.First() <= elf1Range.Last())
            {
                return true;
            }

            if (elf1Range.First() >= elf2Range.First() && elf1Range.First() <= elf2Range.Last())
            {
                return true;
            }
            return false;
        }
    }
}
