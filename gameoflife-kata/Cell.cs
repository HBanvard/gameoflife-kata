namespace gameoflife_kata
{
    public class Cell
    {
        public bool IsLive { get; set; }
        public int NumberOfLiveNeighbors { get; set; }

        public Cell(bool isLive)
        {
            IsLive = isLive;
        }

        public bool CalculateNextState()
        {
            if (NumberOfLiveNeighbors == 3 || (IsLive && NumberOfLiveNeighbors == 2))
            {
                return true;
            }

            return false;
        }
    }
}
