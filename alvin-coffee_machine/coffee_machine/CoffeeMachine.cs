using System;
using System.Collections.Generic;
using System.Linq;

namespace coffee_machine
{
    public class CoffeeMachine
    {
        private List<Drink> _DrinksMade = new List<Drink>();
        private List<string> _Messages = new List<string>();
        private ReportingTool _ReportingTool = new ReportingTool();
        private readonly IEmailNotifier _EmailNotifier;
        private readonly IBeverageQuantityChecker _BeverageQuantityChecker;

        public CoffeeMachine(IEmailNotifier emailNotifier, IBeverageQuantityChecker beverageQuantityChecker)
        {
            _EmailNotifier = emailNotifier;
            _BeverageQuantityChecker = beverageQuantityChecker;
        }

        private void MakeDrink(Drink drink, int sugars)
        {
            if (_BeverageQuantityChecker.IsEmpty(drink))
            {
                _EmailNotifier.NotifyMissingDrink(drink);
                return;
            }
            drink.Sugars = sugars;
            _DrinksMade.Add(drink);
            _ReportingTool.AddDrink(drink); // How do I make a "Spy" class?
        }

        public Drink LastDrink()
        {
            return _DrinksMade.Last();
        }

        public string LastMessage()
        {
            return _Messages.Last();
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
                _Messages.Add(((MessageCommand) GivenCommand).Message);
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
                _Messages.Add(NotEnoughMoneyMessage(money, drinkCommand.DrinkType));
            }
        }

        private bool CheckMoneyIsEnoughForDrink(decimal money, Drink drinkType) => money >= drinkType.Price();

        private string NotEnoughMoneyMessage(decimal money, Drink drinkType) => $"You need {drinkType.Price() - money} more to make a {drinkType.GetType().Name}.";

        public string Report() => _ReportingTool.Report();

    }
}