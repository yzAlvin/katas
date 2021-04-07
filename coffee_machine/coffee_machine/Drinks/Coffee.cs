namespace coffee_machine
{
    public class Coffee : Drink
    {
        public Coffee(int sugars = 0, Temperature temperature = Temperature.Normal)
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