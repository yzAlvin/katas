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

        public override decimal Price()
        {
            return 0.6m;
        }
    }
}