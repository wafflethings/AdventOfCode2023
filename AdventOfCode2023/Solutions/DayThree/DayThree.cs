using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.DayThree
{
    public class DayThree
    {
        public static Positional<char>[][] Characters;

        public static IEnumerable<string> Solve(string[] input)
        {
            SetCharacterArray(ref Characters, input);
            IEnumerable<Part> parts = Part.FindParts(Characters);

            yield return SumAllParts(parts).ToString();
            yield return AllGearRatios(parts).ToString();
        }

        public static void SetCharacterArray(ref Positional<char>[][] array, string[] input)
        {
            array = new Positional<char>[input.Length][];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Positional<char>[input[i].Length];
            }

            int lineNumber = 0;

            foreach (string line in input)
            {
                int charNumber = 0;

                foreach (char character in line)
                {
                    array[lineNumber][charNumber] = Positional<char>.Create(array, new Vector2Int(lineNumber, charNumber), character);
                    charNumber++;
                }

                lineNumber++;
            }
        }

        public static int SumAllParts(IEnumerable<Part> parts)
        {
            return parts.Sum(part => part.AdjacentContainSymbol ? part.Number : 0);
        }

        public static int AllGearRatios(IEnumerable<Part> parts)
        {
            foreach (Part part in parts)
            {
                if (part.GetType() == typeof(GearPart))
                {
                    GearPart gp = (GearPart)part;
                }
            }

            return parts.Sum(part => part.GetType() == typeof(GearPart) ? ((GearPart)part).Ratio : 0);
        }
    }
}
