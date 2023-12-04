using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.Day4
{
    public class ScratchCard
    {
        private static List<ScratchCard> _cards = new();

        public static IEnumerable<ScratchCard> GetAll(string[] input)
        {
            _cards.Clear();

            int position = 0;

            foreach (string line in input)
            {
                _cards.Add(new ScratchCard(line.Split(": ")[1], input, position));
                position++;
            }

            return _cards;
        }

        public int Wins => Numbers.Count(x => WinningNumbers.Contains(x));
        public int Score => (int)Math.Pow(2, Wins - 1);

        public readonly bool IsOriginal;
        public List<int> WinningNumbers = new();
        public List<int> Numbers = new();

        public ScratchCard(string input, string[] sourceArray, int position, bool isOriginal = true)
        {
            IsOriginal = isOriginal;
            string[] halves = input.Split("|");

            foreach (string winningNumber in halves[0].Split(" "))
            {
                string cleaned = winningNumber.Replace(" ", string.Empty);

                if (cleaned != string.Empty)
                {
                    WinningNumbers.Add(int.Parse(cleaned));
                }
            }

            foreach (string number in halves[1].Split(" "))
            {
                string cleaned = number.Replace(" ", string.Empty);

                if (cleaned != string.Empty)
                {
                    Numbers.Add(int.Parse(cleaned));
                }
            }

            for (int i = 0; i < Wins; i++)
            {
                cards.Add(new ScratchCard(sourceArray[position + i + 1].Split(": ")[1], sourceArray, position + i + 1, false));
            }
        }
    }
}
