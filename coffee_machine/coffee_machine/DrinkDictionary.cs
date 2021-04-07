using System;
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

        private static readonly Dictionary<Type, Char> drinkCodes = new Dictionary<Type, Char>() 
        {
            {typeof(OrangeJuice), 'O'},
            {typeof(Tea), 'T'},
            {typeof(HotChocolate), 'H'},
            {typeof(Coffee), 'C'}
        };

        private static readonly Dictionary<char, Temperature> temperatures = new Dictionary<char, Temperature>()
        {
            {'h', Temperature.ExtraHot},
            {'c', Temperature.ExtraCold}
        };

        public static Drink GetDrink(char drinkType) => drinkTypes[drinkType];
        public static Char GetCode(Type drinkType) => drinkCodes[drinkType];
        public static Temperature GetTemperature(char temperatureCode) => temperatures[temperatureCode];
        public static List<char> PossibleDrinks() => new List<char>(drinkTypes.Keys);
    }
    
}
