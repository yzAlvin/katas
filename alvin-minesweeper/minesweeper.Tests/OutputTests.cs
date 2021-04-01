using Xunit;
using Moq;
using System.IO;
using System;

namespace minesweeper.Tests
{
    public class OutputTests
    {
        [Fact]
        public void Output_Calculates_Number_Of_Neighbouring_Mines()
        {
            var expectedFieldString = "*100\n2210\n1*10\n1110";
            
            var field = new Field(4, 4);
            field.SetMine(new Location(0, 0));
            field.SetMine(new Location(1, 2));
            // *...
            // ....
            // .*..
            // ....

            var mockWriteLine = Mock.Of<TextWriter>();
            var consoleOutput = new Output(mockWriteLine);
            
            var actualFieldString = consoleOutput.FieldToString(field);
            
            Assert.Equal(expectedFieldString, actualFieldString);
        }

        [Fact]
        public void Write_Field_To_Console()
        {
            var expectedOutput = "*100\n2210\n1*10\n1110";
            
            var field = new Field(4, 4);
            field.SetMine(new Location(0, 0));
            field.SetMine(new Location(1, 2));

            var mockWriteLine = Mock.Of<TextWriter>();
            var consoleOutput = new Output(mockWriteLine);

            consoleOutput.WriteField(field);
            
            Mock.Get(mockWriteLine).Verify(o => o.WriteLine(expectedOutput), Times.Once);
        }
    }
}
