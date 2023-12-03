using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.DayThree
{
    public class DayThree
    {
        public static IEnumerable<string> Solve(string[] input)
        {
            IEnumerable<EnginePart> parts = EnginePart.FindEngineParts(input);

            yield return SumAllParts(parts).ToString();
        }

        public static int SumAllParts(IEnumerable<EnginePart> parts)
        {
            return parts.Sum(part => part.IsAdjacent ? part.Number : 0);
        }
    }
}
