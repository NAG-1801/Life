using System;
using System.Collections.Generic;

namespace McKinsey.GameOfLife
{
    [Serializable]
    public class Row
    {
        public List<Cell> Cells { get; set; }
    }
}