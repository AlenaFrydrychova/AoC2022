using System.Reflection;

namespace AdventOfCode2022
{
    public class Day08
    {
        public void SolvePuzzle()
        {
            var input = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day08.txt"));
            var lines = input.Split(Environment.NewLine).ToList();

            var forestLenght = lines.Count();
            var forestWidth = lines[0].Length;

            var visibleTrees = 0;

            foreach (var line in lines)
            {
                var lineNumber = lines.IndexOf(line);
                var treePosition = 0;
                foreach (var tree in line)
                {
                    var treeInt = Int32.Parse(tree.ToString());
                    if (treePosition == 0 || treePosition == line.Length - 1 || lineNumber == 0 || lineNumber == forestLenght - 1)
                    {
                        visibleTrees++;
                        treePosition++;
                        continue;
                    }

                    var leftTrees = line.Substring(0, treePosition);
                    var maxLeft = ConvertToInts(leftTrees).Max();

                    var rightTrees = line.Substring(treePosition + 1);
                    var maxRight = ConvertToInts(rightTrees).Max();

                    var currentColumn = GetColumn(treePosition, lines);
                    var maxUp = currentColumn.GetRange(0, lineNumber).Max();
                    var down = currentColumn.GetRange(lineNumber + 1, forestLenght - lineNumber - 1);
                    var maxDown = down.Max();
                    if (treeInt > maxLeft || treeInt > maxRight || treeInt > maxUp || treeInt > maxDown)
                    {
                        visibleTrees++;
                    }

                    treePosition++;
                }
            }
            Console.WriteLine(visibleTrees);
        }

        private List<int> ConvertToInts(string leftTrees)
        {
            var trees = new List<int>();
            foreach (var tree in leftTrees)
            {
                trees.Add(Int32.Parse(tree.ToString()));
            }
            return trees;
        }

        private List<int> GetColumn(int index, List<string> input)
        {
            var column = new List<int>();
            foreach (var line in input)
            {
                column.Add(Int32.Parse(line[index].ToString()));
            }

            return column;
        }
    }
}
