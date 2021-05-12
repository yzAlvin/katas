using System;
using Xunit;

namespace string_calculator.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ConvertStringToNumber_ReturnsZero_WhenStringIsEmpty()
        {
            var expectedResult = 0;
            var actualInput = "";

            var actualResult = Calculator.ConvertStringToNumber(actualInput);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("2", 2)]
        [InlineData("4", 4)]
        [InlineData("3", 3)]
        [InlineData("10", 10)]
        public void ConvertStringToNumber_ReturnsDigit_WhenStringIsNotZero(string actualInput, int expectedResult)
        {

            var actualResult = Calculator.ConvertStringToNumber(actualInput);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,5", 8)]
        [InlineData("1,2,3", 6)]
        [InlineData("3,5,3,9", 20)]
        [InlineData("1,2,\n3", 6)]
        [InlineData("3\n5\n3,9", 20)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[*][%]\n1*2%3", 6)]
        public void AddNumbers_ReturnsTheAdditionOfNumbers(string actualInput, int expectedResult)
        {
            var actualResult = Calculator.AddNumbers(actualInput);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddNegativeNumers_ThrowsException()
        {
            Assert.Throws<Exception>(() => Calculator.AddNumbers("-2,-4"));
        }

        [Theory]
        [InlineData("10000,2", 2)]
        [InlineData("1000, 1001", 0)]
        public void AddNumbersGreaterThan1000_ReturnsTwo(string actualInput, int expectedResult)
        {
            var actualResult = Calculator.AddNumbers(actualInput);
            Assert.Equal(expectedResult, actualResult);
        }

    }
}
