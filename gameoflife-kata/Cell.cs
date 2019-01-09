namespace gameoflife_kata
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsLive { get; set; }
        public int NumberOfLiveNeighbors { get; set; }

        public Cell(int row, int column, bool isLive)
        {
            Row = row;
            Column = column;
            IsLive = isLive;
        }
    }
}
