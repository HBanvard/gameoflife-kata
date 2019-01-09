using gameoflife_kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace gameoflife_kata_tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CountLiveNeighborsTest()
        {
            // Test for non-edge cell
            Cell nonEdgeCell = new Cell(1, 1, true);
            List<Cell> cells = new List<Cell>
            {
                nonEdgeCell,
                new Cell(0, 0, true),
                new Cell(0, 1, true),
                new Cell(0, 2, true),
                new Cell(1, 0, false),
                new Cell(1, 2, false),
                new Cell(2, 0, false),
                new Cell(2, 1, false),
                new Cell(2, 2, false)
            };
       
            Assert.AreEqual(3, Program.CountLiveNeighbors(nonEdgeCell, cells));

            // Test for edge cell
            Cell edgeCell = new Cell(0, 3, true);
            cells.Add(edgeCell);
            cells.Add(new Cell(0, 4, true));
            cells.Add(new Cell(1, 3, false));
            cells.Add(new Cell(1, 4, false));

            Assert.AreEqual(2, Program.CountLiveNeighbors(edgeCell, cells));
            
            // Confirm non-adjacent cells are not counted
            Assert.AreEqual(3, Program.CountLiveNeighbors(nonEdgeCell, cells));
        }

        [TestMethod]
        public void CalculateNextStateTest()
        {
            // Test for live cell
            Cell liveCell = new Cell(0, 0, true);
            liveCell.NumberOfLiveNeighbors = 1;

            Assert.AreEqual(false, Program.CalculateNextState(liveCell));

            liveCell.NumberOfLiveNeighbors = 2;
            Assert.AreEqual(true, Program.CalculateNextState(liveCell));

            liveCell.NumberOfLiveNeighbors = 4;
            Assert.AreEqual(false, Program.CalculateNextState(liveCell));

            // Test for dead cell
            Cell deadCell = new Cell(0, 4, false);
            deadCell.NumberOfLiveNeighbors = 1;

            Assert.AreEqual(false, Program.CalculateNextState(deadCell));

            deadCell.NumberOfLiveNeighbors = 3;
            Assert.AreEqual(true, Program.CalculateNextState(deadCell));

            deadCell.NumberOfLiveNeighbors = 4;
            Assert.AreEqual(false, Program.CalculateNextState(deadCell));
        }
    }
}
