using System.Collections.Generic;
using System.Linq;

namespace minesweeper
{
    public class Field
    {
        public int Rows { get; }
        public int Cols { get; }
        public List<Cell> Cells { get; } = new List<Cell>();
        //initially tried Cell[,], 2D array

        public Field(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            InitialiseCells();
        }

        private void InitialiseCells()
        {
            for (var y = 0; y < Rows; y++)
            {
                for (var x = 0; x < Cols; x++)
                {
                    Cells.Add(new Cell(new Location(x, y)));
                }
            }
        }

        public void SetMine(Location location)
        {
            GetCell(location).IsMine = true;
        }

        public Cell GetCell(Location location) //private
        {
            return Cells.SingleOrDefault(cell => cell.Location.X == location.X && cell.Location.Y == location.Y);
        }

        public IEnumerable<Cell> GetNeighbouringCells(Location location)
        // or instead of taking location it takes a cell?
        {
            var neighbouringCells = new List<Cell>
            {
                GetCell(new Location(location.X-1, location.Y-1)),
                GetCell(new Location(location.X-1, location.Y)),
                GetCell(new Location(location.X-1, location.Y+1)),
                GetCell(new Location(location.X+1, location.Y-1)),
                GetCell(new Location(location.X+1, location.Y)),
                GetCell(new Location(location.X+1, location.Y+1)),
                GetCell(new Location(location.X, location.Y+1)),
                GetCell(new Location(location.X, location.Y-1))
            };
            
            return neighbouringCells.Where(cell => cell != null);
        }

        public int CountNeighbouringMines(Location location) => GetNeighbouringCells(GetCell(location).Location).Count(cell => cell.IsMine);
    }
}