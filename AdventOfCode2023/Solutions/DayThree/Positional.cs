using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions.DayThree
{
    public class Positional<T>
    {
        public Vector2Int Position { get; private init; } = new(0, 0);
        public Positional<T>[][]? Array { get; private init; }
        public T? Value;

        public static Positional<T> Create(Positional<T>[][] array, Vector2Int position, T value)
        {
            Positional<T> created = new()
            {
                Array = array,
                Position = position,
                Value = value
            };

            return created;
        }

        public Positional<T> GetRelative(Vector2Int direction)
        {
            try
            {
                if (Array == null)
                {
                    throw new Exception($"Positional<{typeof(T)}>.GetRelative() has null array; whar?");
                }

                Vector2Int location = Position + direction;
                return Array[location.X][location.Y];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Positional<T>> GetAllAdjacent()
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    yield return GetRelative(new Vector2Int(x, y));
                }
            }
        }

        // public static implicit operator T?(Positional<T> p) => p.Value;
    }
}
