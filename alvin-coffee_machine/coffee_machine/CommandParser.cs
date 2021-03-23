using System.Collections.Generic;
using System.Linq;

namespace coffee_machine
{
    public static class CommandParser
    {

        public static bool TryParse(string commandToParse, out IMachineCommand command)
        {
            if (IsMessageCommand(commandToParse))
            {
                command = GetMessageCommand(commandToParse);
                return true;
            }

            if (IsDrinkCommand(commandToParse))
            {
                command = GetDrinkCommand(commandToParse);
                return true;
            }

            command = GetMessageCommand("Command type not found..");
            return false;
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

        private static ErrorCommand GetErrorCommand(string errorMessage)
        {
            return new ErrorCommand(errorMessage);
        }

        private static DrinkCommand GetDrinkCommand(string commandToParse)
        {
            var partsOfDrink = commandToParse.Split(":");
            var drinkType = GetDrinkType(partsOfDrink[0][0]);
            var sugars = GetSugars(partsOfDrink[1]);
            return new DrinkCommand(drinkType, sugars);
        }

        private static readonly Dictionary<char, DrinkType> drinkTypes = new Dictionary<char, DrinkType>()
        {
            {'T', DrinkType.Tea},
            {'H', DrinkType.HotChocolate},
            {'C', DrinkType.Coffee}
        };

        private static DrinkType GetDrinkType(char drinkType)
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