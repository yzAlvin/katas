using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life
{
    public class Location
    {
        public Coordinate Coordinate { get; private set; }
        public ICell Cell { get; private set; }

        public Location(Coordinate coordinate = default, ICell cell = default)
        {
            if (coordinate == default) coordinate = new Coordinate(0, 0, 0);
            if (cell == default) cell = new DeadCell();
            this.Coordinate = coordinate;
            this.Cell = cell;
        }

        public Location BecomeAlive() =>
            new Location(this.Coordinate, new LivingCell());

        public Location BecomeDead() =>
            new Location(this.Coordinate, new DeadCell());

        public override bool Equals(object obj)
        {
            Location otherLocation = obj as Location;
            if (otherLocation == null) return false;
            return Coordinate.Equals(otherLocation.Coordinate)
            && Cell.GetType().Equals(otherLocation.Cell.GetType());
        }
    }
}