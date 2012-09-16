using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using System.Linq;

namespace McKinsey.GameOfLife.Test
{
    [TestClass]
    public class GameTests
    {
        private Grid _resultGrid;

        public void AnyLiveCellWithFewerThanTwoLiveNeighboursDies(Cell cell)
        {
            var count = cell.Neighbours.Count(p => p != null && p.HasLife);

            if (count < 2)
                Assert.IsFalse(cell.HasLife);

        }


        public void AnyLiveCellWithMoreThanThreeLiveNeighboursDies(Cell cell)
        {
            var count = cell.Neighbours.Count(p => p != null && p.HasLife);

            if (count > 3)
                Assert.IsFalse(cell.HasLife);
        }


        public void AnyLiveCellWithTwoOrThreeLiveNeighboursLives(Cell cell)
        {
            var count = cell.Neighbours.Count(p => p != null && p.HasLife);

            if (count == 2 || count == 3)
                Assert.IsTrue(cell.HasLife);
        }

        public void AnyDeadCellWithExactlyThreeLiveNeighboursComesToLife(Cell cell)
        {
            var count = cell.Neighbours.Count(p => p != null && p.HasLife);

            if (count == 3)
                Assert.IsTrue(cell.HasLife);
        }

        [TestMethod]
        public void IntializeFirstGenerationTest()
        {
            var grid = new Grid(5, 5);
            grid.InitializeCells();
            _resultGrid = grid.RunLife();
            IoCContainer.Container.RegisterInstance(typeof(Grid), _resultGrid);
            foreach (var row in _resultGrid.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    AnyLiveCellWithFewerThanTwoLiveNeighboursDies(cell);
                    AnyLiveCellWithMoreThanThreeLiveNeighboursDies(cell);
                    AnyLiveCellWithTwoOrThreeLiveNeighboursLives(cell);
                    AnyDeadCellWithExactlyThreeLiveNeighboursComesToLife(cell);
                }
            }
        }
    }
}