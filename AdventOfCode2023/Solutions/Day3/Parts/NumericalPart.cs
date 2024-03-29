﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.Common.TwoDimensionalArrays;

namespace AdventOfCode2023.Solutions.Day3.Parts
{
    public class NumericalPart : Part
    {
        public NumericalPart(IEnumerable<Positional<char>> createdFrom) : base(createdFrom)
        {

        }

        public NumericalPart(Positional<char> createdFrom) : base(createdFrom)
        {

        }

        public override int Number
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
    }
}
