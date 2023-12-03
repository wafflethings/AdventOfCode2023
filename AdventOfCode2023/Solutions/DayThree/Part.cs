using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.DayThree
{
    public class Part
    {
        public static IEnumerable<Part> FindParts(Positional<char>[][] array)
        {
            foreach (Positional<char>[] line in array)
            {
                int characterNumber = 0;
                List<Positional<char>> consecutiveNumbers = new();

                foreach (Positional<char> character in line)
                {
                    if (char.IsDigit(character.Value))
                    {
                        consecutiveNumbers.Add(character);
                    }

                    bool lastCharacter = characterNumber == line.Length - 1;
                    if (!char.IsDigit(character.Value) || lastCharacter)
                    {
                        yield return new Part(consecutiveNumbers);
                        consecutiveNumbers.Clear();
                    }

                    characterNumber++;
                }
            }
        }

        public Part(IEnumerable<Positional<char>> createdFrom)
        {
            CreatedFrom = createdFrom;
        }

        public int Number
        {
            get
            {
                int sum = 0;
                int multiplier = 1;

                foreach (Positional<char> character in CreatedFrom.Reverse())
                {
                    sum += int.Parse(character.Value.ToString()) * multiplier;
                    multiplier *= 10;
                } 

                return sum;
            }
        }

        public bool AdjacentsContainSymbol
        {
            get
            {
                foreach (Positional<char> character in AdjacentWithoutSelf())
                {
                    if (character != null && !char.IsDigit(character.Value) && character.Value != '.')
                    {
                        return true;
                    }
                }

                return false;
            }
        }

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

        public override string ToString()
        {
            return $"{Number}: {AdjacentsContainSymbol}";
        }
    }
}