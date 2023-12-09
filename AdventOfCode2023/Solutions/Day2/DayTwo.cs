using AdventOfCode2023.Solutions.Day2.Types;

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

        private static int SumAllGameIds(IEnumerable<ElfGame> games)
        {
            return games.Sum(game => game.GameWasPossible ? game.GameId : 0);
        }

        private static int SumAllPowers(IEnumerable<ElfGame> games)
        {
            return games.Sum(game => game.GetPower(game.GetMaxes));
        }
    }
}
