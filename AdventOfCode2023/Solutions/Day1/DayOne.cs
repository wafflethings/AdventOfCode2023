using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.Day1
{
    public class DayOne
    {
        public static readonly char[] Numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static readonly List<KeyValuePair<string, string>> NumberNameToNumber = new()
        {
            new("one", "1"),
            new("two", "2"),
            new("three", "3"),
            new("four", "4"),
            new("five", "5"),
            new("six", "6"),
            new("seven", "7"),
            new("eight", "8"),
            new("nine", "9"),
            new("zero", "0"),
        };

        public static IEnumerable<string> Solve(string[] input)
        {
            yield return ReturnSum(input, false).ToString();
            yield return ReturnSum(input, true).ToString();
        }

        public static int ReturnSum(IEnumerable<string> lines, bool parseString)
        {
            int sum = 0;

            foreach (string line in lines)
            {
                sum += FirstAndSecond(line, parseString);
            }

            return sum;
        }

        public static int FirstAndSecond(string input, bool parseString)
        {
            int[] numbers = GetNumbers(input, parseString).ToArray();
            return numbers[0] * 10 + numbers[^1];
        }

        public static IEnumerable<int> GetNumbers(string input, bool parseString)
        {
            string startInput = input;

            if (parseString)
            {
                int index = 0;
                input = string.Empty;

                while (index < startInput.Length)
                {
                    input += startInput[index];

                    foreach (KeyValuePair<string, string> replacementPair in NumberNameToNumber)
                    {
                        while (input.Contains(replacementPair.Key))
                        {
                            input = input.Replace(replacementPair.Key, replacementPair.Value + replacementPair.Key[^1]);
                        }
                    }

                    index++;
                }
            }

            IEnumerable<char> chars = input.Where(character => Numbers.Contains(character));

            foreach (char character in chars)
            {
                yield return int.Parse(character.ToString());
            }
        }
    }
}
