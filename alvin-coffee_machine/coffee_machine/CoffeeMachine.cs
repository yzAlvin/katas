using System;
using System.Collections.Generic;
using System.Linq;

namespace coffee_machine
{
    public class CoffeeMachine
    {
        private List<Drink> DrinksMade = new List<Drink>();
        private List<string> Messages = new List<string>();

        public CoffeeMachine()
        {
        }

        public void MakeDrink(Drink drink, int sugars)
        {
            drink.Sugars = sugars;
            DrinksMade.Add(drink);
        }

        public Drink LastDrink()
        {
            return DrinksMade.Last();
        }

        public string LastMessage()
        {
            return Messages.Last();
        }

        public void GiveCommand(string commandToParse, decimal money = 0)
        {
            var GivenCommand = CommandParser.TryParse(commandToParse); 
            // I want to do polymorphism here but don't know how
            // why: because if we add more commands in the future it will be a pain to change this if statement?
            // MAYBE ICOMMAND IS BAD USE OF INTERFACE????

            if (GivenCommand is DrinkCommand)
            {
                ProcessDrinkCommand(money, (DrinkCommand)GivenCommand);
            }
            else
            {
                Messages.Add(((MessageCommand) GivenCommand).Message);
            }
        }

        private void ProcessDrinkCommand(decimal money, DrinkCommand drinkCommand)
        {
            if (CheckMoneyIsEnoughForDrink(money, drinkCommand.DrinkType))
            {
                MakeDrink(drinkCommand.DrinkType, drinkCommand.Sugars);
            }
            else
            {
                Messages.Add(NotEnoughMoneyMessage(money, drinkCommand.DrinkType));
            }
        }

        private bool CheckMoneyIsEnoughForDrink(decimal money, Drink drinkType) => money >= drinkType.Price();

        private string NotEnoughMoneyMessage(decimal money, Drink drinkType) => $"You need {drinkType.Price() - money} more to make a {drinkType}.";

    }
}