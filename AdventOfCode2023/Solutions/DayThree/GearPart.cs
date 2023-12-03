using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.Solutions.DayThree;

namespace AdventOfCode2023.Solutions.DayThree
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
                int numbers = 0;

                foreach (NumericalPart npart in GearNumbers)
                {
                    product *= npart.Number;
                    numbers++;
                }

                return numbers == 2 ? product : 0;
            }
        }

        // this is some of the worst code i have ever written
        public IEnumerable<NumericalPart> GearNumbers
        {
            get
            {
                Console.WriteLine("======");
                Positional<char> gear = CreatedFrom.First();

                List<Positional<char>> alreadyFound = new();
                Vector2Int[] combinations =
                {
                    // all non diagonals; these must be checked first https://i.imgur.com/qk8zSoE.png
                    new(-1, 0),
                    new(1, 0),
                    new(0, -1),
                    new(0, 1),

                    // all diagonals
                    new(-1, -1),
                    new(1, -1),
                    new(-1, 1),
                    new(1, 1),
                    new(-1, -1),
                    new(-1, 1),
                    new(1, -1),
                    new(1, 1),
                };

                foreach (Vector2Int combination in combinations)
                {
                    int x = combination.X;
                    int y = combination.Y;

                    Positional<char> start = gear.GetRelative(new Vector2Int(x, y));

                    if (start != null && char.IsDigit(start.Value) && !alreadyFound.Contains(start))
                    {
                        NumericalPart np = GetAllLinked(start);
                        if (np != null)
                        {
                            alreadyFound.AddRange(np.CreatedFrom);
                            Console.WriteLine("Got number " + np.Number);
                            yield return np;
                        }
                    }
                }
            }
        }

        public NumericalPart GetAllLinked(Positional<char>? start)
        {
            List<Positional<char>> characters = new();
            Positional<char>? lastCharacter = start;

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