using System;

namespace gameoflife_kata
{
    public class Grid
    {
        public Cell[,] Cells { get; set; }

        public Grid(string[] gridContents)
        {
            Cells = new Cell[gridContents.Length, gridContents[0].Length];
            for (int rowCounter = 0; rowCounter < gridContents.Length; rowCounter++)
            {
                for (int columnCounter = 0; columnCounter < gridContents[0].Length; columnCounter++)
                {
                    Cells[rowCounter, columnCounter] = new Cell(gridContents[rowCounter][columnCounter] == 'o' ? true : false);
                }
            }
        }

        public void Display()
        {
            for (int rowCounter = 0; rowCounter < Cells.GetLength(0); rowCounter++)
            {
                for (int columnCounter = 0; columnCounter < Cells.GetLength(1); columnCounter++)
                {
                    Console.Write(Cells[rowCounter, columnCounter].IsLive ? "o" : ".");
                }
                Console.WriteLine();
            }
        }

        public int CountLiveNeighbors(int row, int column)
        {
            int numberOfLiveNeighbors = 0;

            int minRow = Math.Max(row - 1, 0);
            int maxRow = Math.Min(row + 1, Cells.GetLength(0) - 1);
            int minColumn = Math.Max(column - 1, 0);
            int maxColumn = Math.Min(column + 1, Cells.GetLength(1) - 1);

            for (int rowCounter = minRow; rowCounter <= maxRow; rowCounter++)
            {
                for (int columnCounter = minColumn; columnCounter <= maxColumn; columnCounter++)
                {
                    if (Cells[rowCounter, columnCounter].IsLive && !(rowCounter == row && columnCounter == column))
                    {
                        numberOfLiveNeighbors++;
                    }
                }
            }

            return numberOfLiveNeighbors;
        }
    }
}
