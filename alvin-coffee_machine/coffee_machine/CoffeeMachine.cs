using System;
using System.Collections.Generic;
using System.Linq;

namespace coffee_machine
{
    public class CoffeeMachine
    {
        private List<Drink> DrinksMade = new List<Drink>();
        private List<string> Messages = new List<string>();
        private ReportingTool ReportingTool = new ReportingTool();

        public CoffeeMachine()
        {
        }

        private void MakeDrink(Drink drink, int sugars)
        {
            drink.Sugars = sugars;
            DrinksMade.Add(drink);
            ReportingTool.AddDrink(drink); // How do I make a "Spy" class?
        }

        public Drink LastDrink()
        {
            return DrinksMade.Last();
        }

        public string LastMessage()
        {
            return Messages.Last();
        }

        public void GiveCommand(string commandToParse, decimal money = 0) // Return a tuple containing Drink or Message ??
        {
            var GivenCommand = CommandParser.TryParse(commandToParse); 

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

        private string NotEnoughMoneyMessage(decimal money, Drink drinkType) => $"You need {drinkType.Price() - money} more to make a {drinkType.GetType().Name}.";

        public string Report() => ReportingTool.Report();

    }
}