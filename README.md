# gameoflife-kata

## How to Run
To run the program, from the root directory of the project, enter `"dotnet run --project gameoflife-kata/gameoflife-kata.csproj"` on the command line.

To run the unit tests, from the root directory of the project, enter `"dotnet test gameoflife-kata-tests/gameoflife-kata-tests.csproj"` on the command line.

## Requirements and Additional Features
The program accepts an initial grid from the user where each cell in the grid is either alive or dead. The program calculates and displays the next state of the grid based on the rules that (1) an alive cell lives only if it has exactly two or three alive neighbors and (2) a dead cell becomes alive only if it has exactly three alive neighbors.

As additional features, the program allows the user to specify the size of the grid and to choose whether to continue calculating and displaying the next state of the grid.

## Algorithm and Design Choices
The program stores the initial grid provided by the user in a list of objects of type `Cell`. Each cell has integer `Row` and `Column` properties calculated by reference to the size of the grid specified by the user. The initial state (alive or dead) of each cell is stored in a boolean `IsLive` property.

The program calculates the next state of the grid by calling two methods on each cell:
* First, the `CountLiveNeighbors()` method counts the number of cells adjacent to a cell that are alive and stores the result in the cell's `NumberOfLiveNeighbors` property. Adjacent cells are those (1) one row away from the cell and either in the same column as the cell or one column away from the cell and (2) in the same row as the cell and one column away from the cell.
* Next, the `CalculateNextState()` method updates the `IsLive` property of a cell for the next state of the grid by applying the rules of the game to the cell's existing `IsLive` and `NumberOfLiveNeighbors` properties.
