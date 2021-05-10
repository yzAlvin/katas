using System;
using System.IO;
using Xunit;

namespace Game_of_Life.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Generates_And_Ticks_Over_2D_World_Console()
        {
            var worldSize = "5x4";
            var lifeCoords = "0,1.2,1.2,3.3,3";

            var fakeInput = new FakeInput();
            var sequenceOfInput = new string[] { worldSize, lifeCoords };
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

        [Fact]
        public void Game_Skips_Over_Invalid_Input()
        {
            var worldSize = "5x4";
            var garbage = "i am garbage";
            var lifeCoords = "0,1.2,1.2,3.3,3";

            var fakeInput = new FakeInput();
            var sequenceOfInput = new string[] { garbage, worldSize, garbage, lifeCoords, garbage };
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

        [Fact]
        public void Game_Generates_And_Ticks_Over_3D_World_Console()
        {
            var worldSize = "3x3x3";
            var lifeCoords = "0,0,0 . 1,1,1 . 2,2,2";

            var fakeInput = new FakeInput();
            var sequenceOfInput = new string[] { worldSize, lifeCoords };
            fakeInput.SetupSequence(sequenceOfInput);

            var fakeOutput = new FakeOutput();
            var fakeSleeper = new FakeSleeper();

            var expectedGenerationOneWorldString = $"*..|...|...\n...|.*.|...\n...|...|..*\n";
            var expectedGenerationTwoWorldString = $"***|***|***\n***|***|***\n***|***|***\n";
            var expectedGenerationThreeWorldString = $"...|...|...\n...|...|...\n...|...|...\n";

            var game = new Game(fakeInput, fakeOutput, fakeSleeper);
            game.Run();

            Assert.Equal(1, fakeInput.readStrings[worldSize]);
            Assert.Equal(1, fakeInput.readStrings[lifeCoords]);

            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOneWorldString]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwoWorldString]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThreeWorldString]);

            Assert.Equal(2, fakeSleeper.Calls);
        }

        [Fact]
        public void Game_Generates_And_Ticks_Over_2D_World_From_File()
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



    }
}