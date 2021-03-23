using System.Collections.Generic;
using System.Linq;

namespace coffee_machine
{
    public class CoffeeMachine
    {
        private List<Drink> DrinksMade = new List<Drink>();

        public CoffeeMachine()
        {
        }

        public void MakeDrink(DrinkCommand instructions)
        {
            var drink = new Drink(instructions.DrinkType, instructions.Sugars);
            DrinksMade.Add(drink);
        }

        public Drink LastDrink()
        {
            return DrinksMade.Last();
        }

        public void TakeCommand(string commandToParse)
        {
            CommandParser.TryParse(commandToParse, out var command); 
            
            if (command is DrinkCommand)
            {
                MakeDrink(command);
            }
        }

    }
}