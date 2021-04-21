using System.Collections.Generic;

namespace Game_of_Life
{
    public interface ILocation<T>
    {
        void BecomeAlive();
        void BecomeDead();
        // bool Equals();
        T Clone();
        IEnumerable<T> Neighbours();
    }
}