using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.Day2.Types
{
    public class ElfGame
    {
        public static readonly string Prefix = "Game ";
        public static readonly string PrefixEnd = ":";
        public static readonly string GrabSeparator = "; ";

        public int GameId;
        public List<IndividualGrab> Grabs = new();

        public ElfGame(string deserializeFrom)
        {
            GameId = int.Parse(deserializeFrom.Substring(Prefix.Length, deserializeFrom.IndexOf(PrefixEnd) - Prefix.Length));
            deserializeFrom = deserializeFrom.Substring(deserializeFrom.IndexOf(PrefixEnd) + 2);

            foreach (string grab in deserializeFrom.Split(GrabSeparator))
            {
                Grabs.Add(new IndividualGrab(grab));
            }
        }

        public bool GameWasPossible
        {
            get
            {
                foreach (IndividualGrab grab in Grabs)
                {
                    foreach (KeyValuePair<string, int> colourPair in IndividualGrab.ColourMaximums)
                    {
                        if (grab.CubesOfColour[colourPair.Key] > colourPair.Value)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        public IEnumerable<int> GetMaxes
        {
            get
            {
                Dictionary<string, int> colourToMax = new();

                foreach (string colour in IndividualGrab.ColourMaximums.Select(kvp => kvp.Key))
                {
                    colourToMax.Add(colour, 0);
                }

                foreach (IndividualGrab grab in Grabs)
                {
                    foreach (KeyValuePair<string, int> colourPair in grab.CubesOfColour)
                    {
                        if (colourToMax[colourPair.Key] < colourPair.Value)
                        {
                            colourToMax[colourPair.Key] = colourPair.Value;
                        }
                    }
                }

                foreach (int max in colourToMax.Values)
                {
                    yield return max;
                }
            }
        }

        public int GetPower(IEnumerable<int> source)
        {
            int product = 1;

            foreach (int num in source)
            {
                product *= num;
            }

            return product;
        }
    }
}
