using AdventOfCode2023.Solutions.Day2.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.Day2
{
    public static class DayTwo
    {
        public static IEnumerable<string> Solve(string[] input)
        {
            IEnumerable<ElfGame> games = input.Select(str => new ElfGame(str));

            yield return SumAllGameIds(games).ToString();
            yield return SumAllPowers(games).ToString();
        }

        public static int SumAllGameIds(IEnumerable<ElfGame> games)
        {
            return games.Sum(game => game.GameWasPossible ? game.GameId : 0);
        }

        public static int SumAllPowers(IEnumerable<ElfGame> games)
        {
            return games.Sum(game => game.GetPower(game.GetMaxes));
        }
    }
}
