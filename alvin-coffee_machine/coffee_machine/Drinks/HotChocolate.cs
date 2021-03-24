namespace coffee_machine
{
    public class HotChocolate : IDrink
    {
        public HotChocolate()
        {
            Sugars = 0;
        }

        public HotChocolate(int sugars)
        {
            Sugars = sugars;
        }

        public int Sugars { get; set; }

        public DrinkType DrinkType { get => DrinkType.HotChocolate; }

        public bool HasStick()
        {
            return Sugars > 0;
        }

        public static decimal Price()
        {
            return 0.5m;
        }
    }
}