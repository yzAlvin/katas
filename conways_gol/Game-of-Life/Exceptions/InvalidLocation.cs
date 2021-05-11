using System;
using System.Runtime.Serialization;

namespace Game_of_Life
{
    [Serializable]
    public class InvalidLocation : Exception
    {
        public InvalidLocation()
        {
        }

        public InvalidLocation(string message) : base(message)
        {
        }
    }
}