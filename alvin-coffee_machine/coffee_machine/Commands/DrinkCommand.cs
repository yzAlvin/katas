namespace coffee_machine
{
    public class DrinkCommand : IMachineCommand
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