using System;
using Xunit;

namespace coffee_machine.Tests
{
    public class CoffeeMachineTests
    {
        [Theory]
        [InlineData("T:1:0", DrinkType.Tea, 1, true)]
        [InlineData("H::", DrinkType.HotChocolate, 0, false)]
        [InlineData("C:2:0", DrinkType.Coffee, 2, true)]
        public void Order_Parses_DrinkCommands(string drinkCommands, DrinkType expectedDrinkType, int expectedSugars, bool expectedStick)
        {
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.TakeCommand(drinkCommands);
            var drink = coffeeMachine.LastDrink();
            Assert.Equal(expectedDrinkType, drink.DrinkType);
            Assert.Equal(expectedSugars, drink.Sugars);
            Assert.Equal(expectedStick, drink.HasStick);
            
        }
    }
}
