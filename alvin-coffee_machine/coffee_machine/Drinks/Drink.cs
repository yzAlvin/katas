using System;
namespace coffee_machine
{
    public class Drink
    {
        public virtual int Sugars {get; set;}

        public virtual decimal Price() => throw new NotImplementedException();
        public virtual bool HasStick() => Sugars > 0;

        public override string ToString()
        {
            return base.ToString()[15..];
        }
    }
}