using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
namespace McKinsey.GameOfLife
{
    [Serializable]
    public class Cell
    {
        public bool HasLife { get; set; }
        public List<Cell> Neighbours
        {
            get
            {
                var grid = (Grid)IoCContainer.Container.Resolve(typeof(Grid));

                var positions = Extentions.GetNeighboursPositions(Position);
                return positions.Select(position => grid[position.I, position.J]).ToList();
            }
        }
        public Position Position { get; set; }
    }
}