using System;
using System.Linq;
using Xunit;

namespace coffee_machine.Tests
{
    public class CoffeeMachineMakingDrinksTests
    {
        CoffeeMachine coffeeMachine = new CoffeeMachine();
        
        [Theory]
        [InlineData("T:1:0", 1, typeof(Tea), 1, true)]
        [InlineData("H::", 1, typeof(HotChocolate), 0, false)]
        [InlineData("H:0:", 1, typeof(HotChocolate), 0, false)]
        [InlineData("C:2:0", 1, typeof(Coffee), 2, true)]
        [InlineData("O::", 1, typeof(OrangeJuice), 0, false)]
        public void Machine_Returns_Drink_On_Drink_Commands(string drinkCommands, decimal money, Type expectedDrink, int expectedSugars, bool expectedStick)
        {
            coffeeMachine.GiveCommand(drinkCommands, money);
            var drink = coffeeMachine.LastDrink();

            Assert.True(drink.GetType() == expectedDrink);
            Assert.Equal(expectedSugars, drink.Sugars);
            Assert.Equal(expectedStick, drink.HasStick());
        }
        
        [Theory]
        [InlineData("Th::", 1, typeof(ExtraHot), 0.4)]
        [InlineData("Hh::", 1, typeof(ExtraHot), 0.5)]
        [InlineData("Ch::", 1, typeof(ExtraHot), 0.6)]
        public void Machine_Returns_Extra_Hot_Drinks_On_Exta_Hot_Drink_Commands(string drinkCommands, decimal money, Type expectedDrink, decimal expectedCost)
        {
            coffeeMachine.GiveCommand(drinkCommands, money);
            var drink = coffeeMachine.LastDrink();
            Assert.True(drink.Price() == expectedCost);
            Assert.True(drink.GetType() == expectedDrink);
        }

        [Fact]
        public void Machin_Throws_Exception_On_Extra_Hot_OrangeJuice()
        {
            var expectedExceptionMessage = "Orange Juice can't be extra hot.";
            var exception = Assert.Throws<InvalidOperationException>(() =>  coffeeMachine.GiveCommand("Oh::", 1));
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }
        
        [Theory]
        [InlineData("T:1:0", 0, "You need 0.4 more to make a Tea.")]
        [InlineData("H::", 0.1, "You need 0.4 more to make a HotChocolate.")]
        [InlineData("H:0:", 0.3, "You need 0.2 more to make a HotChocolate.")]
        [InlineData("C:2:0", 0.59, "You need 0.01 more to make a Coffee.")]
        [InlineData("O::", 0.59, "You need 0.01 more to make a OrangeJuice.")]
        public void Machine_Returns_Missing_Money_When_Money_Provided_Insufficient(string drinkCommands, decimal money, string expectedMessage)
        {
            coffeeMachine.GiveCommand(drinkCommands, money);
            var message = coffeeMachine.LastMessage();
            Assert.Equal(expectedMessage, message);            
        }

        [Theory]
        [InlineData("T:-1:0", "Cannot have negative sugars.")]
        public void Machine_Throws_Exception_On_Negative_Sugars(string badCommands, string expectedExceptionMessage)
        {
            var exception = Assert.Throws<InvalidOperationException>(() =>  coffeeMachine.GiveCommand(badCommands));
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData("M:Empty Tray", "Empty Tray")]
        [InlineData("M:", "")]
        public void Machine_Returns_Message_On_Message_Commands(string messageCommands, string expectedMessage)
        {
            coffeeMachine.GiveCommand(messageCommands);
            var actualMessage = coffeeMachine.LastMessage();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Theory]
        [InlineData("A:1:0", "Invalid command.")]
        [InlineData(":2:0", "Invalid command.")]
        [InlineData("", "Invalid command.")]
        public void Machine_Throws_Exception_On_Invalid_Commands(string invalidCommands, string expectedExceptionMessage)
        {
            var exception = Assert.Throws<InvalidOperationException>(() =>  coffeeMachine.GiveCommand(invalidCommands));
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

    }
}
