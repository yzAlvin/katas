using System;
using System.IO;
using Xunit;

namespace Game_of_Life.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Runs_Over_2D_World_From_Console()
        {
            var worldSize = "3x4";
            var lifeCoords = "0,0.1,1.1,2";

            var fakeInput = new FakeInput();
            var sequenceOfInput = new string[] { worldSize, lifeCoords, "", "" };
            fakeInput.SetupSequence(sequenceOfInput);

            var fakeOutput = new FakeOutput();
            var fakeSleeper = new FakeSleeper();

            var expectedGenerationOne = $"*...\n.**.\n....\n";
            var expectedGenerationTwo = $".*..\n.*..\n.*..\n";
            var expectedGenerationThree = $"***.\n***.\n***.\n";
            var expectedEmptyWorld = $"....\n....\n....\n";

            var game = new Game(fakeInput, fakeOutput, fakeSleeper);
            game.Run();

            Assert.Equal(1, fakeInput.readStrings[worldSize]);
            Assert.Equal(1, fakeInput.readStrings[lifeCoords]);

            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOne]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwo]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThree]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedEmptyWorld]);

            Assert.Equal(3, fakeSleeper.Calls);
        }

        [Fact]
        public void Game_Skips_Over_Invalid_Input()
        {
            var worldSize = "5x4";
            var garbage = "i am garbage";
            var lifeCoords = "0,1.2,1.2,3.3,3";

            var fakeInput = new FakeInput();
            var sequenceOfInput = new string[] { garbage, worldSize, garbage, lifeCoords, "", "" };
            fakeInput.SetupSequence(sequenceOfInput);

            var fakeOutput = new FakeOutput();
            var fakeSleeper = new FakeSleeper();

            var expectedGenerationOne = $".*..\n....\n.*.*\n...*\n....\n";
            var expectedGenerationTwo = $"....\n*.*.\n*.*.\n*.*.\n....\n";
            var expectedGenerationThree = $"....\n....\n*.*.\n....\n....\n";
            var expectedEmptyWorld = $"....\n....\n....\n....\n....\n";

            var game = new Game(fakeInput, fakeOutput, fakeSleeper);
            game.Run();

            Assert.Equal(1, fakeInput.readStrings[worldSize]);
            Assert.Equal(1, fakeInput.readStrings[lifeCoords]);

            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOne]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwo]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThree]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedEmptyWorld]);

            Assert.Equal(3, fakeSleeper.Calls);
        }

        [Fact]
        public void Game_Plays_Over_3D_World_From_Console()
        {
            var worldSize = "3x3x3";
            var lifeCoords = "0,0,0 . 1,1,1 . 2,2,2";

            var fakeInput = new FakeInput();
            var sequenceOfInput = new string[] { worldSize, lifeCoords, "", "" };
            fakeInput.SetupSequence(sequenceOfInput);

            var fakeOutput = new FakeOutput();
            var fakeSleeper = new FakeSleeper();

            var expectedGenerationOne = $"*..|...|...\n...|.*.|...\n...|...|..*\n";
            var expectedGenerationTwo = $"***|***|***\n***|***|***\n***|***|***\n";
            var expectedGenerationThree = $"...|...|...\n...|...|...\n...|...|...\n";

            var game = new Game(fakeInput, fakeOutput, fakeSleeper);
            game.Run();

            Assert.Equal(1, fakeInput.readStrings[worldSize]);
            Assert.Equal(1, fakeInput.readStrings[lifeCoords]);

            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOne]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwo]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThree]);

            Assert.Equal(2, fakeSleeper.Calls);
        }

        [Fact]
        public void Game_Plays_Over_World_From_File()
        {
            var pathToTestWorld = @"/Users/Alvin.Zhao/Projects/katas/conways_gol/Game-of-Life/exampleWorlds/testWorld.txt";
            var fileReader = File.OpenText(pathToTestWorld);
            var fakeOutput = new FakeOutput();
            var fakeSleeper = new FakeSleeper();
            var game = new Game(fileReader, fakeOutput, fakeSleeper);

            var expectedGenerationOne = $"*...\n.**.\n....\n";
            var expectedGenerationTwo = $".*..\n.*..\n.*..\n";
            var expectedGenerationThree = $"***.\n***.\n***.\n";
            var expectedEmptyWorld = $"....\n....\n....\n";

            game.Run();
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOne]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwo]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThree]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedEmptyWorld]);
            Assert.Equal(3, fakeSleeper.Calls);
        }

        [Fact]
        [Trait("Category", "NotThreadSafe")]
        public void Game_Runs_Over_2D_World_From_Console_With_Custom_CellStrings()
        {
            var worldSize = "4x5";
            var lifeCoords = "0,1.2,1.2,3.3,3";
            string deadCellString = "🐙";
            string liveCellString = "🙊";

            var fakeInput = new FakeInput();
            var sequenceOfInput = new string[] { worldSize, lifeCoords, deadCellString, liveCellString };
            fakeInput.SetupSequence(sequenceOfInput);

            var fakeOutput = new FakeOutput();
            var fakeSleeper = new FakeSleeper();

            var expectedGenerationOne = $"🐙🙊🐙🐙🐙\n🐙🐙🐙🐙🐙\n🐙🙊🐙🙊🐙\n🐙🐙🐙🙊🐙\n";
            var expectedGenerationTwo = $"🐙🐙🐙🐙🐙\n🐙🐙🙊🐙🐙\n🐙🐙🙊🐙🐙\n🐙🐙🐙🐙🐙\n";
            var expectedGenerationThree = $"🐙🐙🐙🐙🐙\n🐙🐙🐙🐙🐙\n🐙🐙🐙🐙🐙\n🐙🐙🐙🐙🐙\n";

            var game = new Game(fakeInput, fakeOutput, fakeSleeper);
            game.Run();

            Assert.Equal(1, fakeInput.readStrings[worldSize]);
            Assert.Equal(1, fakeInput.readStrings[lifeCoords]);

            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationOne]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationTwo]);
            Assert.Equal(1, fakeOutput.writtenStrings[expectedGenerationThree]);

            Assert.Equal(2, fakeSleeper.Calls);
        }




    }
}