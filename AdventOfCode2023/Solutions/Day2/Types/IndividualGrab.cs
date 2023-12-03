using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.Day2.Types
{
    public class IndividualGrab
    {
        public static readonly List<KeyValuePair<string, int>> ColourMaximums = new()
        {
            new("red", 12),
            new("green", 13),
            new("blue", 14)
        };

        public Dictionary<string, int> CubesOfColour = new();

        public IndividualGrab(string deserializeFrom)
        {
            foreach (string cubes in deserializeFrom.Split(", "))
            {
                string[] data = cubes.Split(" ");
                CubesOfColour.Add(data[1], int.Parse(data[0]));
            }

            foreach (KeyValuePair<string, int> colourPair in ColourMaximums)
            {
                if (!CubesOfColour.ContainsKey(colourPair.Key))
                {
                    CubesOfColour.Add(colourPair.Key, 0);
                }
            }
        }
    }
}
