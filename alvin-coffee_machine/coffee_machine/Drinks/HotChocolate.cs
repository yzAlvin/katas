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

        public override decimal Price()
        {
            return 0.5m;
        }
    }
}