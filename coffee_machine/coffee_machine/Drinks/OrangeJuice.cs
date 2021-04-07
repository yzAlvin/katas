using System;
namespace coffee_machine
{
    public class OrangeJuice : Drink
    {
        private Temperature _Temperature;
        public override Temperature Temperature 
        {
            get {return this._Temperature;}
            set 
            {
                if (value == Temperature.ExtraHot) throw new InvalidOperationException("Orange Juice can't be extra hot.");
                this._Temperature = value;
            }
        }
        
        public OrangeJuice(int sugars = 0, Temperature temperature = Temperature.Normal)
        {
            this.Sugars = sugars;
            this.Temperature = temperature;
        }

        public override decimal Price()
        {
            return 0.6m;
        }
    }
}