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

            var highestScenicScore = 0;

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
                    var intLeft = ConvertToInts(leftTrees);
                    var maxLeft = intLeft.Max();
                    intLeft.Reverse();
                    var leftScore = GetScenicScore(intLeft, treeInt);

                    var rightTrees = line.Substring(treePosition + 1);
                    var intRight = ConvertToInts(rightTrees);
                    var maxRight = intRight.Max();
                    var rightScore = GetScenicScore(intRight, treeInt);

                    var currentColumn = GetColumn(treePosition, lines);
                    var up = currentColumn.GetRange(0, lineNumber);
                    var maxUp = up.Max();
                    up.Reverse();
                    var upScore = GetScenicScore(up, treeInt);

                    var down = currentColumn.GetRange(lineNumber + 1, forestLenght - lineNumber - 1);
                    var maxDown = down.Max();
                    var downScore = GetScenicScore(down, treeInt);

                    var totalScore = CountScenicScore(upScore, downScore, leftScore, rightScore);
                    highestScenicScore = totalScore > highestScenicScore ? totalScore : highestScenicScore;

                    if (treeInt > maxLeft || treeInt > maxRight || treeInt > maxUp || treeInt > maxDown)
                    {
                        visibleTrees++;
                    }

                    treePosition++;
                }
            }
            Console.WriteLine(visibleTrees);
            Console.WriteLine(highestScenicScore);
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

        private int GetScenicScore(List<int> trees, int currentTree)
        {
            var score = 0;
            foreach (var tree in trees)
            {
                if (tree < currentTree)
                {
                    score++;
                }
                else if (tree == currentTree)
                {
                    score++;
                    break;
                }
                else
                {
                    break;
                }
            }
            return score;
        }

        private int CountScenicScore(int upScore, int downScore, int leftScore, int rightScore)
        {
            return upScore * downScore * leftScore * rightScore;
        }
    }
}
