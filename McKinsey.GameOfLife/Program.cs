using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McKinsey.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(4, 4);
            grid.InitializeCells();

            grid[1, 1].HasLife = true;
            grid[1, 2].HasLife = true;
            grid[2, 1].HasLife = true;
            grid[2, 2].HasLife = true;
            grid[2, 3].HasLife = true;
            grid[3, 3].HasLife = true;

            var result = grid.RunLife();

            for (int i = 0; i < result.Rows.Count; i++)
            {
                for (int j = 0; j < result.Rows[i].Cells.Count; j++)
                {
                    Console.Write(result[i, j].HasLife ? "X" : "-");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
