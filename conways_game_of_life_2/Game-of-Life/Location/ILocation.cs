using System.Collections.Generic;

namespace Game_of_Life
{
    public abstract class ILocation
    {
        public ICell Cell = new DeadCell();
        public void BecomeAlive() => this.Cell = new LivingCell();
        public void BecomeDead() => this.Cell = new DeadCell();
        public override abstract bool Equals(object obj);
        public abstract ILocation Clone();
        public abstract IEnumerable<ILocation> Neighbours();
    }
}