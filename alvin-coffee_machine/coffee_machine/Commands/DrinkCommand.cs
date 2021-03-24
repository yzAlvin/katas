namespace coffee_machine
{
    public class DrinkCommand : ICommand
    {
        public DrinkType DrinkType {get;}
        public int Sugars {get;}

        public DrinkCommand(DrinkType drinkType, int sugars)
        {
            DrinkType = drinkType;
            Sugars = sugars;
        }
        
    }
}