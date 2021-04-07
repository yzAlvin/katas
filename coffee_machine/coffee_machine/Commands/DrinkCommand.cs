namespace coffee_machine
{
    public class DrinkCommand : ICommand
    {
        public Drink DrinkType {get;}
        public int Sugars {get;}
        public Temperature Temperature {get;}

        public DrinkCommand(Drink drinkType, int sugars, Temperature temperature)
        {
            DrinkType = drinkType;
            Sugars = sugars;
            Temperature = temperature;
        }
        
    }
}