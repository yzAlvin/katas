using System;

namespace coffee_machine
{
    public class HotChocolate : Drink
    {
        private Temperature _Temperature;
        public override Temperature Temperature 
        {
            get {return this._Temperature;}
            set 
            {
                if (value == Temperature.ExtraCold) throw new InvalidOperationException("Hot Chocolate can't be extra cold.");
                this._Temperature = value;
            }
        }

        public HotChocolate(int sugars = 0, Temperature temperature = Temperature.Normal)
        {
            this.Sugars = sugars;
            this.Temperature = temperature;
        }

        public override decimal Price()
        {
            return 0.5m;
        }
    }
}