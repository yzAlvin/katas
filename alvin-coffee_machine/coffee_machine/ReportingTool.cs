using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace coffee_machine
{
    public class ReportingTool
    {
        private Dictionary<char, int> _DrinkCounter = DrinkDictionary.PossibleDrinks().ToDictionary(key => key, value => 0);
        private decimal _TotalMoney = 0;

        public ReportingTool()
        {
            
        }

        public void AddDrink(Drink drink)
        {
            if (drink.GetType() == typeof(ExtraHot))
            {
                drink = ((ExtraHot) drink).GetDrink();
            }
            var drinkCode = DrinkDictionary.GetCode(drink.GetType());
            _DrinkCounter[drinkCode] += 1;

            _TotalMoney += drink.Price();
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder("The total of each drinks made are: \n");

            foreach (var drink in _DrinkCounter)
            {
                report.AppendLine($"{drink.Key}: {drink.Value}");
            }

            report.AppendLine($"The coffee machine has earned: ${_TotalMoney}");

            // Console.WriteLine(report.ToString());
            return report.ToString();
        }
    }
}