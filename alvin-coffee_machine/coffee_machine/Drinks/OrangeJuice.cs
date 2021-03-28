namespace coffee_machine
{
    public class OrangeJuice : Drink
    {
        public OrangeJuice()
        {
            Sugars = 0;
        }

        public OrangeJuice(int sugars)
        {
            Sugars = sugars;
        }

        public override decimal Price()
        {
            return 0.6m;
        }
    }
}