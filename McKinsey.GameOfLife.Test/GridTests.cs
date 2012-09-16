using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace McKinsey.GameOfLife.Test
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void CellHasStateTest()
        {
            var cell = new Cell();
            Assert.IsFalse(cell.HasLife);
        }

        [TestMethod]
        public void CellBelongsToAGridTest()
        {
            var grid = new Grid(5, 6);
            Assert.IsTrue(grid[0, 1] != null && grid[0, 1].GetType() == typeof(Cell));
        }

        [TestMethod]
        public void GridHasRowsTest()
        {
            var grid = new Grid(5, 1);
            Assert.AreEqual(grid.Rows.Count, 5);
        }

        [TestMethod]
        public void RowHasCellsTest()
        {
            var grid = new Grid(5, 1);
            Assert.AreEqual(grid.Rows[0].Cells.Count, 1);
        }
    }
}
