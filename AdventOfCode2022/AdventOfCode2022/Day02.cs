using System.Reflection;

namespace AdventOfCode2022
{
    public class Day02
    {
        public void SolvePuzzle()
        {
            var input = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day02.txt"));
            var rounds = input.Split("\r\n").ToList();
            var totalScore = 0;

            foreach (var round in rounds)
            {
                var choices = round.Split(" ");
                totalScore += GetScore(choices);
            }

            Console.WriteLine(totalScore);
        }

        private int GetScore(string[] choices)
        {
            var opponentChoice = choices[0];
            var myChoice = GetShape(choices);

            var score = 0;
            switch (myChoice)
            {
                case "X":
                    score += 1;
                    break;

                case "Y":
                    score += 2;
                    break;

                case "Z":
                    score += 3;
                    break;

                default:
                    return 0;
            }

            switch (opponentChoice, myChoice)
            {
                case ("A", "X"):
                case ("B", "Y"):
                case ("C", "Z"):
                    score += 3;
                    break;

                case ("A", "Y"):
                case ("B", "Z"):
                case ("C", "X"):
                    score += 6;
                    break;

                case ("A", "Z"):
                case ("B", "X"):
                case ("C", "Y"):
                    score += 0;
                    break;

                default:
                    return 0;
            }

            return score;
        }

        private string GetShape(string[] choices)
        {
            var oponentChoice = choices[0];
            var result = choices[1];

            switch (oponentChoice, result)
            {
                case ("A", "Y"):
                case ("B", "X"):
                case ("C", "Z"):
                    return "X"; //rock

                case ("A", "Z"):
                case ("B", "Y"):
                case ("C", "X"):
                    return "Y"; //paper

                case ("A", "X"):
                case ("B", "Z"):
                case ("C", "Y"):
                    return "Z"; //scissors

                default:
                    return string.Empty;
            }
        }
    }
}
