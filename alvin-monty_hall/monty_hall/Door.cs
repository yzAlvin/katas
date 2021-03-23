using System;

namespace monty_hall
{
    public class Door
    {
        public Door(bool containsPrize)
        {
            this.ContainsPrize = containsPrize;
            this.Picked = false;
            this.Revealed = false;
        }
        public bool ContainsPrize { get; private set; }
        public bool Picked { get; set; }
        public bool Revealed { get; set; }

        public override string ToString()
        {
            return $"Prize: {this.ContainsPrize}\nPicked: {this.Picked}\nRevealed: {this.Revealed}";
        }
    }
}