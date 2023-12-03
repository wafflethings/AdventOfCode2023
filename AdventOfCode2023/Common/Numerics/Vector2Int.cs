using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Common.Numerics
{
    public class Vector2Int
    {
        public static IEnumerable<Vector2Int> AllDirections()
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    yield return new Vector2Int(x, y);
                }
            }
        }

        public int X;
        public int Y;

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2Int operator +(Vector2Int v1, Vector2Int v2) => new(v1.X + v2.X, v1.Y + v2.Y);

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
