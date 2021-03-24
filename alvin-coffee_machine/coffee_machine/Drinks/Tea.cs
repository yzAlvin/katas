namespace coffee_machine
{
    public class Tea : IDrink
    {
        public Tea()
        {
            Sugars = 0;
        }

        public Tea(int sugars)
        {
            Sugars = sugars;
        }

        public int Sugars { get; set; }

        public DrinkType DrinkType { get => DrinkType.Tea; }

        public bool HasStick()
        {
            return Sugars > 0;
        }

        public static decimal Price()
        {
            return 0.4m;
        }
    }
}