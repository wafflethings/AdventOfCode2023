using AdventOfCode2023.Solutions.Day1;
using AdventOfCode2023.Solutions.Day2;
using AdventOfCode2023.Solutions.Day3;
using AdventOfCode2023.Solutions.Day4;
using AdventOfCode2023.Solutions.Day5;

namespace AdventOfCode2023
{
    public class Program
    {
        private static readonly string MainPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input");

        private static void Main(string[] args)
        {
            // LogAll(DayOne.Solve(File.ReadAllLines(Path.Combine(MainPath, "Day1.txt"))), "DAY 1: ");
            // LogAll(DayTwo.Solve(File.ReadAllLines(Path.Combine(MainPath, "Day2.txt"))), "DAY 2: ");
            // LogAll(DayThree.Solve(File.ReadAllLines(Path.Combine(MainPath, "Day3.txt"))), "DAY 3: ");
            // LogAll(DayFour.Solve(File.ReadAllLines(Path.Combine(MainPath, "Day4.txt"))), "DAY 4: ");
            LogAll(DayFive.Solve(File.ReadAllLines(Path.Combine(MainPath, "Day5.txt"))), "DAY 5: ");

            Console.ReadKey();
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