using System.Collections.Generic;

namespace coffee_machine
{
    public static class DrinkDictionary
    {
        private static readonly Dictionary<char, Drink> drinkTypes = new Dictionary<char, Drink>() 
        {
            {'O', new OrangeJuice()},
            {'T', new Tea()},
            {'H', new HotChocolate()},
            {'C', new Coffee()}
        };

        public static Drink GetDrink(char drinkType) => drinkTypes[drinkType];

        public static List<char> PossibleDrinks() => new List<char>(drinkTypes.Keys);
    }
    
}
