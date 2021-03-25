namespace coffee_machine
{
    public class DrinkCommand : ICommand
    {
        public Drink DrinkType {get;}
        public int Sugars {get;}

        public DrinkCommand(Drink drinkType, int sugars)
        {
            DrinkType = drinkType;
            Sugars = sugars;
        }
        
    }
}