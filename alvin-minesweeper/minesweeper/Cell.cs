using System;

namespace minesweeper
{
    public class Cell
    {
        public Location Location { get; }
        public bool IsMine { get; set; }

        public Cell(Location location, bool isMine = false)
        {
            if (location.X < 0 | location.Y < 0) throw new ArgumentException("Cell cannot have a negative position.");
            this.Location = location;
            this.IsMine = isMine;
        }
    }
}