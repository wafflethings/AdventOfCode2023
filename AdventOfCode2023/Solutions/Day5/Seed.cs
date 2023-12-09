using System.Diagnostics;

namespace AdventOfCode2023.Solutions.Day5
{
    public class Seed
    {
        public readonly long Id;
        public readonly long Soil;
        public readonly long Fertilizer;
        public readonly long Water;
        public readonly long Light;
        public readonly long Temperature;
        public readonly long Humidity;
        public readonly long Location;
        
        public Seed(long id)
        {
            try
            {
                Id = id;
                Soil = SeedMaps.SeedToSoil[Id];
                Fertilizer = SeedMaps.SoilToFertilizer[Soil];
                Water = SeedMaps.FertilizerToWater[Fertilizer];
                Light = SeedMaps.WaterToLight[Water];
                Temperature = SeedMaps.LightToTemperature[Light];
                Humidity = SeedMaps.TemperatureToHumidity[Temperature];
                Location = SeedMaps.HumidityToLocation[Humidity];
            }
            catch
            {
                Console.WriteLine($"ERROR: {id}");
            }
        }
    }
}