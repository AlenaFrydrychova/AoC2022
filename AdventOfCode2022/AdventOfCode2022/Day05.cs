using System.Reflection;

namespace AdventOfCode2022
{
    public class Day05
    {
        public void SolvePuzzle()
        {
            var instructions = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day05_Instructions.txt"));
            var lines = instructions.Split(Environment.NewLine);
            var crates = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day05_Crates.txt")).Split(Environment.NewLine).ToList();

            foreach (var line in lines)
            {
                try
                {
                    var instr = line.Split("move ").SelectMany(x => x.Split(" from ").SelectMany(x => x.Split(" to "))).ToList();
                    instr.RemoveAt(0);
                    var numberOfCrates = Int32.Parse(instr.ElementAt(0));
                    var startColumn = crates[Int32.Parse(instr.ElementAt(1)) - 1].ToList();
                    var endColumn = crates[Int32.Parse(instr.ElementAt(2)) - 1].ToList();

                    var movingCrates = startColumn.TakeLast(numberOfCrates);
                    endColumn.AddRange(movingCrates);
                    startColumn.RemoveRange(startColumn.Count - numberOfCrates, numberOfCrates);

                    crates[Int32.Parse(instr.ElementAt(1)) - 1] = string.Join("", startColumn);
                    crates[Int32.Parse(instr.ElementAt(2)) - 1] = string.Join("", endColumn);
                }
                catch (ArgumentOutOfRangeException)
                {
                }

            }
            foreach (var crate in crates)
            {
                Console.WriteLine(crate);
            }

        }
    }
}
