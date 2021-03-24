using System;
using System.Collections.Generic;
using System.Linq;

namespace coffee_machine
{
    public class CoffeeMachine
    {
        private List<IDrink> DrinksMade = new List<IDrink>();
        private List<string> Messages = new List<string>();

        public CoffeeMachine()
        {
        }

        public void MakeDrink(DrinkCommand instructions)
        {
            IDrink drink;
            switch (instructions.DrinkType)
            {
                case DrinkType.Coffee:
                    drink = new Coffee(instructions.Sugars);
                    break;
                case DrinkType.HotChocolate:
                    drink = new HotChocolate(instructions.Sugars);
                    break;
                case DrinkType.Tea:
                    drink = new Tea(instructions.Sugars);
                    break;
                default:
                    throw new InvalidOperationException("Your drink does not exist..");
            }

            DrinksMade.Add(drink);
        }

        public IDrink LastDrink()
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
            if (GivenCommand is DrinkCommand){
                DrinkCommand drinkCommand = (DrinkCommand) GivenCommand;
                if (CheckMoneyIsEnoughForDrink(money, (drinkCommand.DrinkType)))
                {
                    MakeDrink(drinkCommand);
                }
                else
                {
                    Messages.Add(NotEnoughMoneyMessage(money, drinkCommand.DrinkType));
                }
            }
            else{
                Messages.Add(((MessageCommand) GivenCommand).Message);
            }
        }

        private bool CheckMoneyIsEnoughForDrink(decimal money, DrinkType drinkType)
        {
            // I want to get rid of switch statement but don't know how
            switch (drinkType)
            {
                case DrinkType.Coffee:
                    return money >= Coffee.Price();
                case DrinkType.HotChocolate:
                    return money >= HotChocolate.Price();
                case DrinkType.Tea:
                    return money >= Tea.Price();
                default:
                    throw new InvalidOperationException("Your drink does not exist..");
            }
        }

        private string NotEnoughMoneyMessage(decimal money, DrinkType drinkType)
        {
            // I want to get rid of switch statement but don't know how
            switch (drinkType)
            {
                case DrinkType.Coffee:
                    return $"You need {Coffee.Price() - money} more to make a Coffee.";
                case DrinkType.HotChocolate:
                    return $"You need {HotChocolate.Price() - money} more to make a HotChocolate.";
                case DrinkType.Tea:
                    return $"You need {Tea.Price() - money} more to make a Tea.";
                default:
                    throw new InvalidOperationException("Your drink does not exist..");
            }
        }

    }
}