using System;
using System.Collections.Generic;

namespace gameoflife_kata
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int CountLiveNeighbors(Cell cell, List<Cell> cells)
        {
            int numberOfLiveNeighbors = 0;

            foreach (Cell testCell in cells)
            {
                if (testCell.IsLive && ((Math.Abs(testCell.Row - cell.Row) == 1 && Math.Abs(testCell.Column - cell.Column) <= 1) ||
                   (testCell.Row == cell.Row && Math.Abs(testCell.Column - cell.Column) == 1)))
                {
                    numberOfLiveNeighbors++;
                }
            }

            return numberOfLiveNeighbors;
        }

        public static bool CalculateNextState(Cell cell)
        {
            if (cell.IsLive)
            {
                if (cell.NumberOfLiveNeighbors == 2 || cell.NumberOfLiveNeighbors == 3)
                {
                    return true;
                }

                return false;
            }

            if (cell.NumberOfLiveNeighbors == 3)
            {
                return true;
            }

            return false;
        }
    }
}
