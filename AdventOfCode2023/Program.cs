using AdventOfCode2023.Solutions.DayOne;
using AdventOfCode2023.Solutions.DayTwo;

namespace AdventOfCode2023
{
    public class Program
    {
        public static readonly string MainPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input");

        private static void Main(string[] args)
        {
            LogAll(DayOne.Solve(File.ReadAllLines(Path.Combine(MainPath, "Day1.txt"))), "DAY 1: ");
            LogAll(DayTwo.Solve(File.ReadAllLines(Path.Combine(MainPath, "Day2.txt"))), "DAY 2: ");
        }

        public static void LogAll(IEnumerable<string> lines, string prefix = "")
        {
            int solution = 1;

            foreach (string line in lines)
            {
                Console.WriteLine($"{prefix}Part {solution} is {line}");
                solution++;
            }
        }
    }
}