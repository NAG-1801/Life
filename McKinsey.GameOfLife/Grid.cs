using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace McKinsey.GameOfLife
{
    [Serializable]
    public class Grid
    {
        private readonly int _rows;
        private readonly int _columns;

        public Grid(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            InitializeCells();
        }

        public Cell this[int row, int column]
        {
            get
            {
                if (row < 0 || column < 0 || row >= _rows || column >= _columns) return null;
                return Rows[row].Cells[column];
            }
            set
            {
                if (_rows <= row || _columns <= column) throw new ArgumentOutOfRangeException("Argument out of bound");
                Rows[row].Cells[column] = value;
            }
        }

        public List<Row> Rows { get; set; }

        public void InitializeCells()
        {
            Rows = new List<Row>();
            for (var i = 0; i < _rows; i++)
            {
                var row = new Row { Cells = new List<Cell>() };

                for (var j = 0; j < _columns; j++)
                {
                    var cell = new Cell();
                    row.Cells.Add(cell);
                }

                Rows.Add(row);
            }

            IoCContainer.Container.RegisterInstance(typeof(Grid), this);

        }

        public Grid RunLife()
        {
            var result = Extentions.DeepClone(this);

            for (var i = 0; i < Rows.Count; i++)
            {
                var cells = Rows[i].Cells;
                for (var j = 0; j < cells.Count; j++)
                {
                    var liveNeighbours = cells[j].Neighbours.Count(x => x != null && x.HasLife);
                    if (cells[j].HasLife)
                    {
                        if (liveNeighbours < 2)
                        {
                            result[i, j].HasLife = false;
                        }

                        if (liveNeighbours > 3)
                        {
                            result[i, j].HasLife = false;
                        }
                    }
                    else
                    {
                        if (liveNeighbours == 3)
                        {
                            result[i, j].HasLife = true;
                        }
                    }
                }
            }

            return result;
        }

    }
}