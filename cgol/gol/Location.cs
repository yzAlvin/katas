namespace gol
{
    public class Location
    {
        private int x;
        private int y;

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            Location location = obj as Location;
            if (location == null) return false;
            return x == location.x && y == location.y;
        }
    }
}