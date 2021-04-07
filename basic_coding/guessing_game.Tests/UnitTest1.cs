using System;
using Xunit;
using guessing_game;

namespace guessing_game.Tests
{
    public class UnitTest1
    {
        Program test = new Program();
        [Fact]
        public void VerifyGuess_IsInt_Test()
        {
            string[] ListOfInts = new string[] {"1", "100"};
            foreach (string n in ListOfInts)
            {
                Assert.True(test.VerifyGuess(n));
            }
            
        }
        [Fact]
        public void VerifyGuess_IsNotInt_Test()
        {
            string[] ListOfNotInts = new string[] {"true", "null", "hello", "2.3"};
            foreach (string n in ListOfNotInts)
            {
                Assert.False(test.VerifyGuess(n));
            }
            
        }
        [Fact]
        public void VerifyGuess_IsInRange_Test()
        {
            string[] ListOfInts = new string[] {"-10", "0", "101"};
            foreach (string n in ListOfInts)
            {
                Assert.False(test.VerifyGuess(n));
            }
            
        }
    }
}
