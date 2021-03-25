using System;
using System.Collections.Generic;
using System.Linq;

namespace coffee_machine
{
    public static class CommandParser
    {

        public static ICommand TryParse(string commandToParse)
        {
            // CODE SMELLS TO ME!!!!!
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
            var drinkCommandCodes = new string[] {"C:", "H:", "T:"};
            return drinkCommandCodes.Any(commandToParse.StartsWith);
        }

        private static MessageCommand GetMessageCommand(string commandToParse)
        {
            var message = commandToParse[2..];
            return new MessageCommand(message);
        }

        private static DrinkCommand GetDrinkCommand(string commandToParse)
        {
            var partsOfDrink = commandToParse.Split(":");
            var drinkType = GetDrinkType(partsOfDrink[0][0]);
            var sugars = GetSugars(partsOfDrink[1]);
            if (sugars < 0) throw new InvalidOperationException("Cannot have negative sugars.");
            return new DrinkCommand(drinkType, sugars);
        }

        private static readonly Dictionary<char, Drink> drinkTypes = new Dictionary<char, Drink>()
        {
            // COMMAND PARSER SHOULDN'T BE THE ONE CREATING INSTANCES OF OBJECTS!!!!
            {'T', new Tea()},
            {'H', new HotChocolate()},
            {'C', new Coffee()}
        };

        private static Drink GetDrinkType(char drinkType)
        {
            return drinkTypes[drinkType];
        }

        private static int GetSugars(string amountOfSugar)
        {
            int.TryParse(amountOfSugar, out var sugars);
            return sugars;
        }
    }
}