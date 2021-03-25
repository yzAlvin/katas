namespace coffee_machine
{
    public class Tea : Drink
    {
        public Tea()
        {
            Sugars = 0;
        }

        public Tea(int sugars)
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
            return 0.4m;
        }
    }
}