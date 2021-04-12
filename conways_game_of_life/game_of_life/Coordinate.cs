using System;
using System.Collections.Generic;
namespace game_of_life
{
    public class Coordinate
    {
        private int _x {get;}
        private int _y {get;}
        public ICell Cell {get; set;}

        public Coordinate(int x, int y)
        {
            if (x < 0 || y < 0) throw new ArgumentException("Coordinates cannot be negative.");
            _x = x;
            _y = y;
            Cell = new DeadCell();
        }

        public void BecomeAlive()
        {
            Cell = new LivingCell();
        }

        // public static Coordinate Random()
        // {
        //     return new Coordinate(1, 1);
        // }

        public override bool Equals(object obj)
        {
            Coordinate otherCoord = obj as Coordinate;
            return _x == otherCoord._x && _y == otherCoord._y;
        }

    }
}