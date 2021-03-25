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

        public override decimal Price()
        {
            return 0.4m;
        }
    }
}