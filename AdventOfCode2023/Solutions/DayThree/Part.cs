using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.DayThree
{
    public abstract class Part
    {
        public static IEnumerable<Part> FindParts(Positional<char>[][] array)
        {
            foreach (Positional<char>[] line in array)
            {
                int characterNumber = 0;
                List<Positional<char>> consecutiveNumbers = new();

                foreach (Positional<char> character in line)
                {
                    if (character.Value == '*')
                    {
                        yield return new GearPart(character);
                    }

                    if (char.IsDigit(character.Value))
                    {
                        consecutiveNumbers.Add(character);
                    }

                    bool lastCharacter = characterNumber == line.Length - 1;
                    if (!char.IsDigit(character.Value) || lastCharacter)
                    {
                        yield return new NumericalPart(consecutiveNumbers);
                        consecutiveNumbers.Clear();
                    }

                    characterNumber++;
                }
            }
        }

        protected Part(IEnumerable<Positional<char>> createdFrom)
        {
            CreatedFrom = createdFrom;
        }

        protected Part(Positional<char> createdFrom)
        {
            CreatedFrom = new[] { createdFrom };
        }

        public abstract int Number { get; }

        public bool AdjacentMatchCriteria(Predicate<Positional<char>> criteria)
        {
            foreach (Positional<char> character in AdjacentWithoutSelf())
            {
                if (character != null && criteria.Invoke(character))
                {
                    return true;
                }
            }

            return false;
        }

        public bool AdjacentContainSymbol => AdjacentMatchCriteria(c => !char.IsDigit(c.Value) && c.Value != '.');

        public IEnumerable<Positional<char>> CreatedFrom;

        public IEnumerable<Positional<char>> AdjacentWithoutSelf()
        {
            foreach (Positional<char> character in CreatedFrom)
            {
                foreach (Positional<char> adjacent in character.GetAllAdjacent())
                {
                    if (!CreatedFrom.Contains(adjacent))
                    {
                        yield return adjacent;
                    }
                }
            }
        }
    }
}