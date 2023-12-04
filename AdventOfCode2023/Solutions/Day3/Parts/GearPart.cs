using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.Common.Numerics;
using AdventOfCode2023.Common.TwoDimensionalArrays;

namespace AdventOfCode2023.Solutions.Day3.Parts
{
     public class GearPart : Part
    {
        public GearPart(IEnumerable<Positional<char>> createdFrom) : base(createdFrom)
        {

        }

        public GearPart(Positional<char> createdFrom) : base(createdFrom)
        {

        }

        public override int Number => 0;

        public int Ratio
        {
            get
            {
                int product = 1;
                int count = 0;

                foreach (NumericalPart gearNumber in GearNumbers)
                {
                    product *= gearNumber.Number;
                    count++;
                }

                return count == 2 ? product : 0;
            }
        }

        public IEnumerable<NumericalPart> GearNumbers
        {
            get
            {
                Positional<char> gear = CreatedFrom.First();
                List<Positional<char>> alreadyFound = new();

                foreach (Vector2Int combination in Vector2Int.AllDirections())
                {
                    Positional<char> start = gear.GetRelative(new Vector2Int(combination.X, combination.Y));

                    if (start != null && char.IsDigit(start.Value) && !alreadyFound.Contains(start))
                    {
                        NumericalPart allNumbers = GetAllLinked(start);
                        alreadyFound.AddRange(allNumbers.CreatedFrom);
                        yield return allNumbers;
                    }
                }
            }
        }

        public NumericalPart GetAllLinked(Positional<char> start)
        {
            List<Positional<char>> characters = new();
            Positional<char> lastCharacter = start;

            while (lastCharacter != null && char.IsDigit(lastCharacter.Value))
            {
                characters.Add(lastCharacter);
                lastCharacter = lastCharacter.GetRelative(new Vector2Int(0, 1));
            }

            lastCharacter = start.GetRelative(new Vector2Int(0, -1));

            while (lastCharacter != null && char.IsDigit(lastCharacter.Value))
            {
                characters.Insert(0, lastCharacter);
                lastCharacter = lastCharacter.GetRelative(new Vector2Int(0, -1));
            }

            return new NumericalPart(characters);
        }
    }
}