namespace coffee_machine
{
    public class Drink
    {
        public DrinkType DrinkType {get;}
        public int Sugars {get;}
        public bool HasStick {get;}

        public Drink(DrinkType drinkType, int sugars)
        {
            DrinkType = drinkType;
            Sugars = sugars;
            HasStick = sugars > 0;
        }
    }
}