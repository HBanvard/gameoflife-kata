using gameoflife_kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace gameoflife_kata_tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CountLiveNeighborsTest()
        {
            Grid grid = new Grid(new string[] { "ooo..", ".o..o", "o..oo"});

            // Test for non-edge cell
            Assert.AreEqual(4, grid.CountLiveNeighbors(1, 1));

            // Test for edge cell
            Assert.AreEqual(2, grid.CountLiveNeighbors(0, 3));
        }

        [TestMethod]
        public void CalculateNextStateTest()
        {
            // Test for live cell
            Cell liveCell = new Cell(true);
            liveCell.NumberOfLiveNeighbors = 1;

            Assert.AreEqual(false, liveCell.CalculateNextState());

            liveCell.NumberOfLiveNeighbors = 2;
            Assert.AreEqual(true, liveCell.CalculateNextState());

            liveCell.NumberOfLiveNeighbors = 4;
            Assert.AreEqual(false, liveCell.CalculateNextState());

            // Test for dead cell
            Cell deadCell = new Cell(false);
            deadCell.NumberOfLiveNeighbors = 1;

            Assert.AreEqual(false, deadCell.CalculateNextState());

            deadCell.NumberOfLiveNeighbors = 3;
            Assert.AreEqual(true, deadCell.CalculateNextState());

            deadCell.NumberOfLiveNeighbors = 4;
            Assert.AreEqual(false, deadCell.CalculateNextState());
        }
    }
}
