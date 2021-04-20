using System;
using System.IO;
using Xunit;

namespace Game_of_Life.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Gets_World()
        {
            var worldSize = "5x4";
            var row1 = ".*...";
            var row2 = ".....";
            var row3 = ".*.*.";
            var row4 = "...*.";
            var shouldNotBeRead = "notRead";

            var fakeInput = new FakeInput();
            var sequenceOfInput = new string[] {worldSize, row1, row2, row3, row4, shouldNotBeRead};
            fakeInput.SetupSequence(sequenceOfInput);

            var fakeOutput = new FakeOutput();
            var fakeOutputStringDictionary = fakeOutput.writtenStrings.Keys;

            var fakeSleeper = new FakeSleeper();

            var expectedGenerationOne = "Generation 1: ";
            var expectedGenerationTwo = "Generation 2: ";
            var expectedGenerationThree = "Generation 3: ";
            var expectedGenerationOneWorldString = $"{row1}\n{row2}\n{row3}\n{row4}\n";
            var expectedGenerationTwoWorldString = $".....\n..*..\n..*..\n.....\n";
            var expectedGenerationThreeWorldString = $".....\n.....\n.....\n.....\n";

            var game = new Game(fakeInput, fakeOutput, fakeSleeper);
            game.Run();

            Assert.Equal(1, fakeInput.readStrings[worldSize]);
            Assert.Equal(1, fakeInput.readStrings[row1]);
            Assert.Equal(1, fakeInput.readStrings[row2]);
            Assert.Equal(1, fakeInput.readStrings[row3]);

            Assert.Contains(expectedGenerationOneWorldString, fakeOutputStringDictionary);
            Assert.Contains(expectedGenerationTwoWorldString, fakeOutputStringDictionary);
            Assert.Contains(expectedGenerationThreeWorldString, fakeOutputStringDictionary);

            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOne]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwo]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThree]);

            Assert.DoesNotContain(shouldNotBeRead, fakeOutputStringDictionary);
        }

        [Fact]
        public void Game_From_File()
        {
            var fileReader = File.OpenText(@"/Users/Alvin.Zhao/Projects/katas/conways_game_of_life_2/Game-of-Life/exampleWorld.txt");
            var fakeOutput = new FakeOutput();
            var fakeSleeper = new FakeSleeper();
            var game = new Game(fileReader, fakeOutput, fakeSleeper);

            var expectedGenerationFour = "Generation 4: ";
            var expectedGenerationFourString = "........\n........\n........\n........\n........\n........\n";

            game.Run();

            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationFour]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationFourString]);
        }
    }
}