namespace coffee_machine
{
    public class Coffee : IDrink
    {
        public Coffee()
        {
            Sugars = 0;
        }

        public Coffee(int sugars)
        {
            Sugars = sugars;
        }

        public int Sugars { get; set; }

        public DrinkType DrinkType { get => DrinkType.Coffee; }

        public bool HasStick()
        {
            return Sugars > 0;
        }

        public static decimal Price()
        {
            return 0.6m;
        }
    }
}