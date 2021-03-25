namespace coffee_machine
{
    public class Coffee : Drink
    {
        public Coffee()
        {
            Sugars = 0;
        }

        public Coffee(int sugars)
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
            return 0.6m;
        }
    }
}