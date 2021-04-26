using System;
using System.IO;
using Xunit;

namespace Game_of_Life.Tests
{
    public class GameTests
    {
        [Fact(Skip = "temp")]
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

            var fakeSleeper = new FakeSleeper();

            var expectedGenerationOneWorldString = $"{row1}\n{row2}\n{row3}\n{row4}\n";
            var expectedGenerationTwoWorldString = $".....\n..*..\n..*..\n.....\n";
            var expectedGenerationThreeWorldString = $".....\n.....\n.....\n.....\n";

            var game = new Game(fakeInput, fakeOutput, fakeSleeper);
            game.Run();

            Assert.Equal(1, fakeInput.readStrings[worldSize]);
            Assert.Equal(1, fakeInput.readStrings[row1]);
            Assert.Equal(1, fakeInput.readStrings[row2]);
            Assert.Equal(1, fakeInput.readStrings[row3]);

            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOneWorldString]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwoWorldString]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThreeWorldString]);

            Assert.Equal(2, fakeSleeper.Calls);

            Assert.DoesNotContain(shouldNotBeRead, fakeOutput.writtenStrings.Keys);
        }

        [Fact(Skip = "temp")]
        public void Game_From_File()
        {
            var pathToTestWorld = @"/Users/Alvin.Zhao/Projects/katas/conways_game_of_life_2/Game-of-Life/exampleWorlds/testWorld.txt";
            var fileReader = File.OpenText(pathToTestWorld);
            var fakeOutput = new FakeOutput();
            var fakeSleeper = new FakeSleeper();
            var game = new Game(fileReader, fakeOutput, fakeSleeper);

            var expectedGenerationOneString = "*.......\n.**.....\n........\n...*....\n...*....\n........\n";
            var expectedGenerationTwoString = ".*......\n.*......\n..*.....\n........\n........\n........\n";
            var expectedGenerationThreeString = "........\n.**.....\n........\n........\n........\n........\n";
            var expectedGenerationFourString = "........\n........\n........\n........\n........\n........\n";

            game.Run();
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOneString]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwoString]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThreeString]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationFourString]);
            Assert.Equal(3, fakeSleeper.Calls);
        }


        [Fact]
        public void Game_Gets_World_pass_coords()
        {
            var worldSize = "5x4";
            var lifeCoords = "()0, 1.2,1.2,  3.3,3";

            var fakeInput = new FakeInput();
            var sequenceOfInput = new string[] {worldSize, lifeCoords};
            fakeInput.SetupSequence(sequenceOfInput);

            var fakeOutput = new FakeOutput();

            var fakeSleeper = new FakeSleeper();

            var expectedGenerationOneWorldString = $".*...\n.....\n.*.*.\n...*.\n";
            var expectedGenerationTwoWorldString = $".....\n..*..\n..*..\n.....\n";
            var expectedGenerationThreeWorldString = $".....\n.....\n.....\n.....\n";

            var game = new Game(fakeInput, fakeOutput, fakeSleeper);
            game.Run();

            Assert.Equal(1, fakeInput.readStrings[worldSize]);
            Assert.Equal(1, fakeInput.readStrings[lifeCoords]);

            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOneWorldString]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwoWorldString]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThreeWorldString]);

            Assert.Equal(2, fakeSleeper.Calls);
        }
    }
}