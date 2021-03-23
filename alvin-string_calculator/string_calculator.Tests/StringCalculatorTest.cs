using System;
using Xunit;

namespace string_calculator.Tests
{
    public class StringCalculatorTest
    {
        StringCalculator test = new StringCalculator();

        [Fact]
        public void Add_WhenEmptyString_ReturnsNum()
        {
            Assert.Equal(0, test.Add(""));
        }
        [Fact]
        public void Add_WhenSingleNumber_ReturnsSingleNumber()
        {
            Assert.Equal(1, test.Add("1"));
            Assert.Equal(3, test.Add("3"));
        }
        [Fact]
        public void Add_WhenTwoNumbers_ReturnsSum()
        {
            Assert.Equal(3, test.Add("1,2"));
            Assert.Equal(8, test.Add("3,5"));
        }
        [Fact]
        public void Add_WhenAnyAmountOfNumbersSeparatedByCommas_ReturnsSum()
        {
            Assert.Equal(6, test.Add("1,2,3"));
            Assert.Equal(20, test.Add("3,5,3,9"));
        }
        [Fact]
        public void Add_WhenListOfNumbersSeparatedByLineBreaks_ReturnsSum()
        {
            Assert.Equal(6, test.Add("1,2\n3"));
            Assert.Equal(20, test.Add("3\n5\n3,9"));
            Assert.Equal(11, test.Add("3\n5\n3"));
        }
        [Fact]
        public void Add_WhenListOfNumbersWithSingleSymbolCharacterDelimiter_ReturnsSum()
        {
            Assert.Equal(3, test.Add("//;\n1;2"));
        }
        [Fact]
        public void Add_WhenListOfNumbersWithNumberSymbolCharacterDelimiter_ReturnsSum()
        {
            Assert.Equal(3, test.Add("//0\n102"));
        }
        [Fact]
        public void Add_WhenListOfNumbersWithSingleLetterCharacterDelimiter_ReturnsSum()
        {
            Assert.Equal(3, test.Add("//a\n1a2"));
        }
        [Fact]
        public void Add_ThrowsExceptionWithASingleNegative()
        {
            var exception = Assert.Throws<NegativesNotAllowedException>(() => test.Add("-1,2"));
            Assert.Equal("Negatives not allowed: -1", exception.Message);
        }
        [Fact]
        public void Add_ThrowsExceptionWithMultipleNegatives()
        {
            var exception = Assert.Throws<NegativesNotAllowedException>(() => test.Add("-1,2,-3"));
            Assert.Equal("Negatives not allowed: -1, -3", exception.Message);
        }
        [Fact]
        public void Add_CanAddNumbersBetween0And999()
        {
            Assert.Equal(1000, test.Add("0,1,999"));
        }
        [Fact]
        public void Add_IgnoresNumbersGreaterThanOrEqual1000()
        {
            Assert.Equal(2, test.Add("2,1000,1001"));
        }
        [Fact]
        public void Add_Returns0IfAllNumbersGreaterThanOrEqual1000()
        {
            Assert.Equal(0, test.Add("1000,1001,2000,9999"));
        }
        [Fact]
        public void Add_DelimiterCanBeAnyLength_NoNumbersInDelimiter()
        {
            Assert.Equal(6, test.Add("//[***]\n1***2***3"));
        }
        [Fact]
        public void Add_DelimiterCanBeAnyLength_NumbersInDelimiter()
        {
            Assert.Equal(6, test.Add("//[*99]\n1*992*993"));
        }
        // [Fact]
        // public void Add_CanContainMultipleDelimiters()
        // {
        //     Assert.Equal(6, test.Add("//[*][%]\n1*2%3"));
        // }
        // [Fact]
        // public void Add_CanContainMultipleDelimitersOfDifferentLengths()
        // {
        //     Assert.Equal(6, test.Add("//[*=][%aa]\n1*=2%aa3"));
        // }
    }
}
