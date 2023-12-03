using AdventOfCode2023.Common.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Common.TwoDimensionalArrays
{
    /// <summary>
    /// A version of T for use with 2D arrays. Similar to a linked list, where it has functions for its parent array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
                // Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Positional<T>> GetAllAdjacent()
        {
            foreach (Vector2Int direction in Vector2Int.AllDirections())
            {
                yield return GetRelative(new Vector2Int(direction.X, direction.Y));
            }
        }

        // public static implicit operator T?(Positional<T> p) => p.Value;
    }
}
