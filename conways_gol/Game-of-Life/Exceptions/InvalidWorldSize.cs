using System;
using System.Runtime.Serialization;

namespace Game_of_Life
{
    [Serializable]
    public class InvalidWorldSize : Exception
    {
        public InvalidWorldSize()
        {
        }

        public InvalidWorldSize(string message) : base(message)
        {
        }

    }
}