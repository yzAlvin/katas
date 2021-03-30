namespace coffee_machine
{
    public class Tea : Drink
    {
        public Tea(int sugars = 0, Temperature temperature = Temperature.Normal)
        {
            this.Sugars = sugars;
            this.Temperature = temperature;
        }

        public override decimal Price()
        {
            return 0.4m;
        }
    }
}