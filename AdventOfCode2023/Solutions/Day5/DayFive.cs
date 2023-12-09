using AdventOfCode2023.Common.TwoDimensionalArrays;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.Common.Numerics;

namespace AdventOfCode2023.Solutions.Day5
{
    public static class DayFive
    {
        public static List<Seed> Seeds = new();
        
        public static IEnumerable<string> Solve(string[] input)
        {
            SeedMaps.FillLists(input, false);
            Seeds.AddRange(CreateSeedList());
            
            yield return Seeds.MinBy(val => val.Location).Location.ToString();
            
            Seeds.Clear();;
            SeedMaps.FillLists(input, true);
            Seeds.AddRange(CreateSeedList());
            yield return Seeds.MinBy(val => val.Location).Location.ToString();
        }

        public static IEnumerable<Seed> CreateSeedList()
        {
            foreach (long id in SeedMaps.SeedIds)
            {
                yield return new Seed(id);
            }
        }

        public static string ToListReal(this IEnumerable<long> list)
        {
            return string.Join(",\n", list);
        }
        
        public static string ToDictReal(this Dictionary<long, long> list)
        {
            return string.Join(",\n", list);
        }
    }
}