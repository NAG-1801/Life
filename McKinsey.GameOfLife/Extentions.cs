using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace McKinsey.GameOfLife
{
    public static class Extentions
    {
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public static IEnumerable<Position> GetNeighboursPositions(Position position)
        {
            var neighbours = new List<Position>
                                 {
                                     new Position(position.I - 1, position.J), // top
                                     new Position(position.I + 1, position.J), // bottom
                                     new Position(position.I, position.J - 1), // left
                                     new Position(position.I, position.J + 1), // right
                                     new Position(position.I - 1, position.J - 1), // top left
                                     new Position(position.I - 1, position.J + 1), // top right
                                     new Position(position.I + 1, position.J - 1), // bottom left
                                     new Position(position.I + 1, position.J + 1) // bottom right
                                 };

            return neighbours;
        }
    }
}