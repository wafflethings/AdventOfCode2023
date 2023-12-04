using AdventOfCode2023.Common.TwoDimensionalArrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.Common.Numerics;

namespace AdventOfCode2023.Solutions.Day4
{
    public class DayFour
    {
        // This is extremely slow.

        public static IEnumerable<string> Solve(string[] input)
        {
            IEnumerable<ScratchCard> cards = ScratchCard.GetAll(input);

            yield return cards.Sum(card => card.IsOriginal ? card.Score : 0).ToString();
            yield return cards.Count().ToString();
        }
    }
}