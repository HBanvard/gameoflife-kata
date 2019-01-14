using System;
using System.Text.RegularExpressions;

namespace gameoflife_kata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] gridDimensions = GetGridDimensions();
            string[] gridContents = GetGridContents(gridDimensions[0], gridDimensions[1]);
            Grid grid = new Grid(gridContents);
            grid.Display();

            bool done = false;
            while (!done)
            {
                for (int rowCounter = 0; rowCounter < grid.Cells.GetLength(0); rowCounter++)
                {
                    for (int columnCounter = 0; columnCounter < grid.Cells.GetLength(1); columnCounter++)
                    {
                        grid.Cells[rowCounter, columnCounter].NumberOfLiveNeighbors = grid.CountLiveNeighbors(rowCounter, columnCounter);
                    }
                }
                foreach (Cell cell in grid.Cells)
                {
                    cell.IsLive = cell.CalculateNextState();
                }

                Console.WriteLine();
                Console.WriteLine("Here is the next state of the grid:");
                Console.WriteLine();
                grid.Display();

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

        public static int[] GetGridDimensions()
        {
            int[] gridDimensions = new int[2];

            Console.WriteLine("Welcome to the Game of Life!");
            Console.WriteLine();
            Console.WriteLine("You will create an grid of cells where each cell is either \"alive\" or \"dead.\"");

            Console.WriteLine();
            while (gridDimensions[0] < 1)
            {
                Console.WriteLine("Please enter the number of rows:");
                try
                {
                    gridDimensions[0] = int.Parse(Console.ReadLine());
                    if (gridDimensions[0] < 1)
                    {
                        Console.WriteLine();
                        Console.Write("Number of rows must be at least 1. ");
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.Write("Not a valid number. ");
                }
            }

            Console.WriteLine();
            while (gridDimensions[1] < 1)
            {
                Console.WriteLine("Please enter the number of columns:");
                try
                {
                    gridDimensions[1] = int.Parse(Console.ReadLine());
                    if (gridDimensions[1] < 1)
                    {
                        Console.WriteLine();
                        Console.Write("Number of columns must be at least 1. ");
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.Write("Not a valid number. ");
                }               
            }

            return gridDimensions;
        }

        public static string[] GetGridContents(int rows, int columns)
        {
            string[] gridContents = new string[rows];

            Console.WriteLine();
            Console.WriteLine($"To create the grid, enter {rows} lines of {columns} characters each.");

            for (int rowCounter = 0; rowCounter <= rows - 1; rowCounter++)
            {
                Console.WriteLine();
                Console.WriteLine($"Line {rowCounter + 1}:\tPlease enter {columns} characters with no spaces.");
                Console.WriteLine("\tEach character must be either the letter \"o\" for an \"alive\" cell or the period symbol \".\" for a \"dead\" cell.");

                string input = Console.ReadLine();
                while (input.Length != columns || !Regex.IsMatch(input, $"[o.]{{{columns}}}"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid format. Please try again.");
                    input = Console.ReadLine();
                }

                gridContents[rowCounter] = input;
            }

            Console.WriteLine();
            Console.WriteLine("Here is the grid you entered:");
            Console.WriteLine();

            return gridContents;
        }
    }
}
