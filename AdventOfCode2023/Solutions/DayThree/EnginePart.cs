using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.DayThree
{
    public class EnginePart
    {
        public int Number = 0;
        public bool IsAdjacent = false;

        public EnginePart(int start, int numberLength, int lineWithNumber, string[] input)
        {
            Number = int.Parse(input[lineWithNumber].Substring(start, numberLength));

            Console.WriteLine("============");
            Console.WriteLine($"Number is {Number}");
            foreach (string line in input)
            {
                int startIdx = start - 1 < 0 ? 0 : start - 1;
                int length = numberLength + 2;

                if (startIdx + length > line.Length)
                {
                    length = (line.Length) - startIdx;
                }

                Console.WriteLine(line.Substring(startIdx, length));
                foreach (char c in line.Substring(startIdx, length))
                {
                    if (!char.IsDigit(c) && c != '.')
                    {
                        IsAdjacent = true;
                    }
                }
            }
            Console.WriteLine(IsAdjacent);
        }

        public static IEnumerable<EnginePart> FindEngineParts(string[] input)
        {
            for (int i = 0; i < input.Length; i++) //foreach line
            {
                string line = input[i];
                int numberLength = 0;

                for (int j = 0; j < line.Length; j++) //foreach char
                {
                    char c = line[j];

                    if (char.IsDigit(c))
                    {
                        numberLength++;
                    }

                    bool atEndOfLine = j == line.Length-1;
                    if (atEndOfLine)
                    {
                        Console.WriteLine("end");
                    }
                    if (!char.IsDigit(c) || atEndOfLine)
                    {
                        if (char.IsDigit(c) && atEndOfLine)
                        {
                            j++;
                        }

                        if (numberLength > 0)
                        {
                            string[] lines = FindLinesToSearch(i, input, out int l);
                            yield return new EnginePart(j - numberLength, numberLength, l, lines);
                        }

                        numberLength = 0;
                    }
                }
            }
        }

        public static string[] FindLinesToSearch(int currentIndex, string[] input, out int lineToSearch)
        {
            if (currentIndex == 0)
            {
                lineToSearch = 0;
                return new string[]
                {
                    input[0], input[1]
                };
            }

            if (currentIndex == input.Length - 1)
            {
                lineToSearch = 1;
                return new string[]
                {
                    input[^2], input[^1]
                };
            }

            lineToSearch = 1;
            return new string[]
            {
                input[currentIndex - 1], input[currentIndex], input[currentIndex + 1]
            };
        }
    }
}
