namespace AdventOfCode2023.Solutions.Day5
{
    public static class SeedMaps
    {
        public static readonly List<long> SeedIds = new();
        public static readonly Dictionary<long, long> SeedToSoil = new();
        public static readonly Dictionary<long, long> SoilToFertilizer = new();
        public static readonly Dictionary<long, long> FertilizerToWater = new();
        public static readonly Dictionary<long, long> WaterToLight = new();
        public static readonly Dictionary<long, long> LightToTemperature = new();
        public static readonly Dictionary<long, long> TemperatureToHumidity = new();
        public static readonly Dictionary<long, long> HumidityToLocation = new();

        public static void FillLists(string[] input, bool seedsAreRanges)
        {
            SeedIds.Clear();
            
            Dictionary<long, long>? previousDict = null;
            Dictionary<long, long>? currentDict = null;
            List<string> lines = new();
            int index = 0;

            foreach (string line in input)
            {
                Console.WriteLine(line);
                if (line.StartsWith("seeds:"))
                {
                    List<long> parsedSeeds = line.Split(": ")[1].Split(" ").Select(long.Parse).ToList();

                    if (!seedsAreRanges)
                    {
                        SeedIds.AddRange(parsedSeeds);
                    }
                    else
                    {
                        while (parsedSeeds.Count != 0)
                        {
                            SeedIds.AddRange(NumberRange(parsedSeeds[0], parsedSeeds[1]));
                            parsedSeeds.RemoveAt(0);
                            parsedSeeds.RemoveAt(0);
                        }
                    }

                    index++;
                    continue;
                }

                string[] splitAtSpace = line.Split(" ");

                if (splitAtSpace.Length == 3)
                {
                    lines.Add(line);
                }

                bool lastLine = index == input.Length - 1;
                
                if (splitAtSpace.Length == 2 || lastLine)
                {
                    Dictionary<long, long> target = GetTargetList(line);
                    
                    if ((target != null && currentDict != target) || lastLine)
                    {
                        IEnumerable<long> previous = previousDict?.Values;
                        if (previous == null)
                        {
                            previous = SeedIds;
                        }
                        
                        SetDictionary(lines, currentDict, previous);
                        lines.Clear();
                        
                        previousDict = currentDict;
                        currentDict = target;
                    }
                }

                index++;
            }
        }

        public static void SetDictionary(IEnumerable<string> lines, Dictionary<long, long> dictionary, IEnumerable<long> previous)
        {
            dictionary?.Clear();
            
            foreach (long previousValue in previous)
            {
                dictionary?.TryAdd(previousValue, previousValue);
            }
            
            foreach (string line in lines)
            {
                string[] splitAtSpace = line.Split(" ");
                long destinationStart = long.Parse(splitAtSpace[0]);
                long sourceStart = long.Parse(splitAtSpace[1]);
                long range = long.Parse(splitAtSpace[2]);
                
                foreach (KeyValuePair<long, long> pair in GenerateRange(sourceStart, destinationStart, range, previous))
                {
                    dictionary[pair.Key] = pair.Value;
                }
            }
        }

        private static Dictionary<long, long>? GetTargetList(string line) => line switch
        {
            "seed-to-soil map:" => SeedToSoil,
            "soil-to-fertilizer map:" => SoilToFertilizer,
            "fertilizer-to-water map:" => FertilizerToWater,
            "water-to-light map:" => WaterToLight,
            "light-to-temperature map:" => LightToTemperature,
            "temperature-to-humidity map:" => TemperatureToHumidity,
            "humidity-to-location map:" => HumidityToLocation,
            _ => null
        };
        
        private static IEnumerable<KeyValuePair<long, long>> GenerateRange(long sourceStart, long destinationStart, long range, IEnumerable<long> previous)
        {
            foreach (long previousValue in previous)
            {
                if (previousValue >= sourceStart && previousValue < sourceStart + range)
                {
                    long difference = previousValue - sourceStart;
                    yield return new KeyValuePair<long, long>(sourceStart + difference, destinationStart + difference);
                }
            }
        }
        
        private static IEnumerable<long> NumberRange(long start, long length)
        {
            for (int i = 0; i < length; i++)
            {
                yield return start + i;
            }
        }
    }
}