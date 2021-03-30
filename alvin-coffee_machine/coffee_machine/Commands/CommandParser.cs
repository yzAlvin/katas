using System;
using System.Collections.Generic;
using System.Linq;

namespace coffee_machine
{
    public static class CommandParser
    {

        public static ICommand TryParse(string commandToParse)
        {
            if (IsMessageCommand(commandToParse))
            {
                return GetMessageCommand(commandToParse);
            }

            if (IsDrinkCommand(commandToParse))
            {
                return GetDrinkCommand(commandToParse);
            }

            throw new InvalidOperationException("Invalid command.");
        }

        private static bool IsMessageCommand(string commandToParse)
        {
            var messageCommandCode = "M:";
            return commandToParse.StartsWith(messageCommandCode);
        }

        private static bool IsDrinkCommand(string commandToParse)
        {
            var drinkCommandCodes = DrinkDictionary.PossibleDrinks();
            return drinkCommandCodes.Any(commandToParse.StartsWith);
        }

        private static MessageCommand GetMessageCommand(string commandToParse)
        {
            var message = commandToParse[2..];
            return new MessageCommand(message);
        }

        private static DrinkCommand GetDrinkCommand(string commandToParse)
        {
            var drinkInstructions = commandToParse.Split(":");
            return ParseDrinkInstructions(drinkInstructions);
        }

        private static Drink GetDrinkType(string[] partsOfDrink)
        {
            var drinkType = partsOfDrink[0][0];
            return DrinkDictionary.GetDrink(drinkType);
        }

        private static int GetSugars(string[] partsOfDrink)
        {
            var amountOfSugar = partsOfDrink[1];
            int.TryParse(amountOfSugar, out var sugars);
            if (sugars < 0) throw new InvalidOperationException("Cannot have negative sugars.");
            return sugars;
        }

        private static Temperature GetTemperature(string[] partsOfDrink)
        {
            if (partsOfDrink[0].Length == 1) return Temperature.Normal;
            if (partsOfDrink[0].Length == 2) return DrinkDictionary.GetTemperature(partsOfDrink[0][1]);
            throw new InvalidOperationException("Invalid Temperature");
        }

        private static DrinkCommand ParseDrinkInstructions(string[] partsOfDrink)
        {
            var drinkType = GetDrinkType(partsOfDrink);
            var sugars = GetSugars(partsOfDrink);
            var temperature = GetTemperature(partsOfDrink);

            return new DrinkCommand(drinkType, sugars, temperature);
        }
    }
}