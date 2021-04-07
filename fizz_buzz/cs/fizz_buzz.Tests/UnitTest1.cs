using System.Linq;
using System.Reflection;
using System;
using Xunit;
using fizz_buzz;

namespace fizz_buzz.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FizzBuzz_FizzBuzz_Test()
        {
            int[] ListOfInts = new int[] {15, 30, 90};
            foreach (int n in ListOfInts)
            {
                Assert.Equal("FizzBuzz", Program.FizzBuzz(n));
            }
        }
        [Fact]
        public void FizzBuzz_Fizz_Test()
        {
            int[] ListOfInts = new int[] {3, 6, 99};
            foreach (int n in ListOfInts)
            {
                Assert.Equal("Fizz", Program.FizzBuzz(n));
            }
        }
        [Fact]
        public void FizzBuzz_Buzz_Test()
        {
            int[] ListOfInts = new int[] {5, 10, 100};
            foreach (int n in ListOfInts)
            {
                Assert.Equal("Buzz", Program.FizzBuzz(n));
            }
        }
        [Fact]
        public void FizzBuzz_NotDivisibleBy3Or5_Test()
        {
            int[] ListOfInts = new int[] {1, 2, 98};
            foreach (int n in ListOfInts)
            {
                Assert.Equal(n.ToString(), Program.FizzBuzz(n));
            }
        }
        [Fact]
        public void NumberList_Size_Test()
        {
            var list = Enumerable.Range(1, 100);
            Assert.True(list.Count() == 100);
        }
        [Fact]
        public void NumberList_Values_Test()
        {
            var list = Enumerable.Range(1, 100);
            Assert.True(list.ElementAt(0) == 1);
        }
    }
}
