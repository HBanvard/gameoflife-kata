using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace gameoflife_kata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Cell> cells = GetInput();
            DisplayGrid(cells);

            bool done = false;
            while (!done)
            {
                foreach (Cell cell in cells)
                {
                    cell.NumberOfLiveNeighbors = CountLiveNeighbors(cell, cells);
                }
                foreach (Cell cell in cells)
                {
                    cell.IsLive = CalculateNextState(cell);
                }

                Console.WriteLine();
                Console.WriteLine("Here is the next state of the grid:");
                Console.WriteLine();
                DisplayGrid(cells);

                Console.WriteLine();
                Console.WriteLine("Would you like to continue? Enter (Y)es or (N)o:");
                string input = Console.ReadLine();
                while (input.ToUpper() != "Y" && input.ToUpper() != "N")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid format. Please enter (Y)es or (N)o:");
                    input = Console.ReadLine();
                }
                if (input.ToUpper() == "N")
                {
                    done = true;
                    Console.WriteLine();
                    Console.WriteLine("Thanks for playing! Press \"Enter\" to exit.");
                    Console.ReadLine();
                }
            }
        }

        public static List<Cell> GetInput()
        {
            List<Cell> cells = new List<Cell>();

            Console.WriteLine("Welcome to the Game of Life!");
            Console.WriteLine();
            Console.WriteLine("You will create an grid of cells where each cell is either \"alive\" or \"dead.\"");

            Console.WriteLine();
            int rows = 0;
            bool rowsSuccess = false;
            while (!rowsSuccess)
            {
                Console.WriteLine("Please enter the number of rows:");
                try
                {
                    rows = int.Parse(Console.ReadLine());
                    rowsSuccess = true;
                }
                catch
                {
                    Console.WriteLine();
                    Console.Write("Not a valid number. ");
                }
            }

            Console.WriteLine();
            int columns = 0;
            bool columnsSuccess = false;
            while (!columnsSuccess)
            {
                Console.WriteLine("Please enter the number of columns:");
                try
                {
                    columns = int.Parse(Console.ReadLine());
                    columnsSuccess = true;
                }
                catch
                {
                    Console.WriteLine();
                    Console.Write("Not a valid number. ");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"To create the grid, enter {rows} lines of {columns} characters each.");
            int counter = 0;
            while (counter <= rows - 1)
            {
                Console.WriteLine();
                Console.WriteLine($"Line {counter + 1}:\tPlease enter {columns} characters with no spaces.");
                Console.WriteLine("\tEach character must be either the letter \"o\" for an \"alive\" cell or the period symbol \".\" for a \"dead\" cell.");

                string input = Console.ReadLine();
                while (input.Length != columns || !Regex.IsMatch(input, $"[o.]{{{columns}}}"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid format. Please try again.");
                    input = Console.ReadLine();
                }

                for (int i = 0; i < columns; i++)
                {
                    cells.Add(new Cell(counter, i, input[i] == 'o' ? true : false));
                }

                counter++;
            }

            Console.WriteLine();
            Console.WriteLine("Here is the grid you entered:");
            Console.WriteLine();

            return cells;
        }

        public static void DisplayGrid(List<Cell> cells)
        {
            int counter = 0;
            while (counter <= cells.Max(c => c.Row))
            {
                foreach (Cell cell in cells.Where(c => c.Row == counter).OrderBy(c => c.Column))
                {
                    Console.Write(cell.IsLive ? "o" : ".");
                }
                counter++;
                Console.WriteLine();
            }
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
