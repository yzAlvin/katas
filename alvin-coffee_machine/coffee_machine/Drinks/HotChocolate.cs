namespace coffee_machine
{
    public class HotChocolate : Drink
    {
        public HotChocolate()
        {
            Sugars = 0;
        }

        public HotChocolate(int sugars)
        {
            Sugars = sugars;
        }

        public override int Sugars { get; set; }

        public override bool HasStick()
        {
            return Sugars > 0;
        }

        public override decimal Price()
        {
            return 0.5m;
        }
    }
}