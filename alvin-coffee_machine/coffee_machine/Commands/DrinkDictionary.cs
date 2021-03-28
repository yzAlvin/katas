using System.Collections.Generic;

namespace coffee_machine
{
    public static class DrinkDictionary
    {
        private static readonly Dictionary<char, Drink> drinkTypes = new Dictionary<char, Drink>() 
        {
            // COMMAND PARSER SHOULDN'T BE THE ONE CREATING INSTANCES OF OBJECTS!!!!
            {'T', new Tea()},
            {'H', new HotChocolate()},
            {'C', new Coffee()}
        };

        public static Drink GetDrink(char drinkType)
        {
            return drinkTypes[drinkType];
        }
    }
    
}
