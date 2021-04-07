using System;
using Xunit;

namespace roman_numerals.Tests
{
    public class RomanNumeralBaseSymbolsTest
    {
        [Fact]
        public void Parse_Integer_1_Returns_I()
        {
            Assert.Equal("I", RomanNumeral.Parse(1));
        }
        [Fact]
        public void Parse_Integer_5_Returns_V()
        {
            Assert.Equal("V", RomanNumeral.Parse(5));
        }
        [Fact]
        public void Parse_Integer_10_Returns_X()
        {
            Assert.Equal("X", RomanNumeral.Parse(10));
        }
        [Fact]
        public void Parse_Integer_50_Returns_L()
        {
            Assert.Equal("L", RomanNumeral.Parse(50));
        }
        [Fact]
        public void Parse_Integer_100_Returns_C()
        {
            Assert.Equal("C", RomanNumeral.Parse(100));
        }
        [Fact]
        public void Parse_Integer_500_Returns_D()
        {
            Assert.Equal("D", RomanNumeral.Parse(500));
        }
        [Fact]
        public void Parse_Integer_1000_Returns_M()
        {
            Assert.Equal("M", RomanNumeral.Parse(1000));
        }
        [Fact]
        public void Parse_Integer_0_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => RomanNumeral.Parse(0));
        }
    }
    public class RomanNumeral9Test
    {
        [Fact]
        public void Parse_Integer_9000_Returns_MMMMMMMMM()
        {
            Assert.Equal("MMMMMMMMM", RomanNumeral.Parse(9000));
        }
        [Fact]
        public void Parse_Integer_900_Returns_CM()
        {
            Assert.Equal("CM", RomanNumeral.Parse(900));
        }
        [Fact]
        public void Parse_Integer_90_Returns_MMMMMMMMM()
        {
            Assert.Equal("XC", RomanNumeral.Parse(90));
        }
        [Fact]
        public void Parse_Integer_9_Returns_MMMMMMMMM()
        {
            Assert.Equal("IX", RomanNumeral.Parse(9));
        }
    }
    public class RomanNumeral4Test
    {
        [Fact]
        public void Parse_Integer_400_Returns_CD()
        {
            Assert.Equal("CD", RomanNumeral.Parse(400));
        }
        [Fact]
        public void Parse_Integer_40_Returns_XL()
        {
            Assert.Equal("XL", RomanNumeral.Parse(40));
        }
        [Fact]
        public void Parse_Integer_4_Returns_IV()
        {
            Assert.Equal("IV", RomanNumeral.Parse(4));
        }
    }
    public class RomanNumeral123Test
    {
        [Fact]
        public void Parse_Integer_300_Returns_CCC()
        {
            Assert.Equal("CCC", RomanNumeral.Parse(300));
        }
        [Fact]
        public void Parse_Integer_100_Returns_C()
        {
            Assert.Equal("C", RomanNumeral.Parse(100));
        }
        [Fact]
        public void Parse_Integer_3_Returns_III()
        {
            Assert.Equal("III", RomanNumeral.Parse(3));
        }
        [Fact]
        public void Parse_Integer_1_Returns_I()
        {
            Assert.Equal("I", RomanNumeral.Parse(1));
        }
    }
    public class RomanNumeral5678Test
    {
        [Fact]
        public void Parse_Integer_800_Returns_DCCC()
        {
            Assert.Equal("DCCC", RomanNumeral.Parse(800));
        }
        [Fact]
        public void Parse_Integer_500_Returns_D()
        {
            Assert.Equal("D", RomanNumeral.Parse(500));
        }
        [Fact]
        public void Parse_Integer_8_Returns_VIII()
        {
            Assert.Equal("VIII", RomanNumeral.Parse(8));
        }
        [Fact]
        public void Parse_Integer_5_Returns_V()
        {
            Assert.Equal("V", RomanNumeral.Parse(5));
        }
    }
    public class RomanNumeralCombinationsTest
    {
        [Fact]
        public void Parse_Integer_34_Returns_XXXIV()
        {
            Assert.Equal("XXXIV", RomanNumeral.Parse(34));
        }
        [Fact]
        public void Parse_Integer_86_Returns_LXXXVI()
        {
            Assert.Equal("LXXXVI", RomanNumeral.Parse(86));
        }
        [Fact]
        public void Parse_Integer_2021_Returns_MMXXI()
        {
            Assert.Equal("MMXXI", RomanNumeral.Parse(2021));
        }
        [Fact]
        public void Parse_Integer_999_Returns_CMXCIX()
        {
            Assert.Equal("CMXCIX", RomanNumeral.Parse(999));
        }
    }
}
