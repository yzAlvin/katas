using System.Reflection;
using System;
using Xunit;
using basic_coding;

namespace basic_coding.Tests
{
    public class UnitTest1
    {
        Program test = new Program();
        // [Fact]
        // public void GetNameTest()
        // {
        //     test.GetName() == string
        // }
        [Fact]
        public void GreetUserTest()
        {
            string name = "alvin";
            Assert.True(test.GreetUser(name)  == $"Hello {name}");
        }
        [Fact]
        public void GreetBobOrAliceTest()
        {
            string name = "Bob";
            Assert.True(test.GreetBobOrAlice(name)  == $"Hello {name}");
            name = "Alice";
            Assert.True(test.GreetBobOrAlice(name)  == $"Hello {name}");
        }
        [Fact]
        public void GreetBobOrAlice_Neither_Test()
        {
            string name = "alvin";
            Assert.True(test.GreetBobOrAlice(name)  == "");
        }
        [Fact]
        public void SumOneToN_Test()
        {
            Assert.True(test.SumOneToN(100)  == 5050);
        }
        [Fact]
        public void SumOneToN_LessThanZero_Test()
        {
            Assert.Throws<InvalidOperationException>(() => test.SumOneToN(0));
        }

        [Fact]
        public void SumOneToNIfMultipleOf3Or5_Test()
        {
            Assert.True(test.SumOneToNIfMultipleOf3Or5(17) == 3+5+6+9+10+12+15);
        }
        [Fact]
        public void ProducOneToN_Test()
        {
            Assert.True(test.ProducOneToN(10) == 3628800);
        }
        [Fact]
        public void ProducOneToN_LessThanZero_Test()
        {
            Assert.Throws<InvalidOperationException>(() => test.ProducOneToN(0));
        }
        [Fact]
        public void MultiplicationTable_Test()
        {
            int[] TwelveTimesTable = new int[12] {12, 24, 36, 48, 60, 72, 84, 96, 108, 120, 132, 144};
            // TwelveTimesTable[0] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable[1] = new int[] {2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24};
            // TwelveTimesTable[2] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable[3] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable[4] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable[5] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable[6] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable[7] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable[8] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable[9] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable[10] = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // TwelveTimesTable = {12, 24, 36, 48, 60, 72, 84, 96, 108, 120, 132, 144};
            Assert.True(test.MultiplicationTable()[11] == TwelveTimesTable);
        }
    }
}
