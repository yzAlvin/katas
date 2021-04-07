using System.Security.Cryptography;
using System.Reflection;
using System;
using Xunit;
using System.Linq;
using Moq;

namespace monty_hall.Tests
{
    public class UnitTest1
    {
        GetRandomNumber mockRandom = new GetRandomNumber(new DeterministicRandom());
        [Fact]
        public void DoorHasPrizeProperty()
        {
            Door doorA = new Door(true);
            Assert.True(doorA.ContainsPrize == (true || false));
        }
        [Fact]
        public void OnlyOneDoorIsTheWinner()
        {
            Monty game = new Monty(1000);
            Assert.True(game.Doors.Where(d => d.ContainsPrize == true).Count() == 1);
            Assert.True(game.Doors.Where(d => d.ContainsPrize == false).Count() == 999);
        }
        [Fact]
        public void MockRandomNumberGeneratorTest()
        {
            var deterministicRandom = new DeterministicRandom();
            var getRandomNumber = new GetRandomNumber(deterministicRandom);
            Assert.Equal(0, getRandomNumber.getRandomInt(0, 10));
        }
        [Fact]
        public void MockDoorThatContainsCarIs0()
        {
            Monty game = new Monty(3, mockRandom);
            Assert.True(game.Doors[0].ContainsPrize == true);
        }
        [Fact]
        public void DoorHasPickedProperty()
        {
            Door doorA = new Door(true);
            Assert.True(doorA.Picked == false);
        }
        [Fact]
        public void ContestantCanPickDoor()
        {
            Monty game = new Monty(3);
            int doorToPick = 0;
            game.PickDoor(doorToPick);
            Assert.True(game.Doors[doorToPick].Picked == true);
        }
        [Fact]
        public void HostRevealsDoorWhenCarPicked()
        {
            Monty game = new Monty(3, mockRandom);
            int doorToPick = 0;
            game.PickDoor(doorToPick);

            game.RevealDoors();

            Assert.True(game.Doors.Where(d => d.Revealed == true).Count() == 1);
        }
        [Fact]
        public void HostRevealsDoorWhenDudPicked()
        {
            Monty game = new Monty(3, mockRandom);
            int doorToPick = 1;
            game.PickDoor(doorToPick);

            game.RevealDoors();

            Assert.True(game.Doors.Where(d => d.Revealed == true).Count() == 1);
        }
        [Fact]
        public void HostRevealsDoorWhenMultipleToReveal()
        {
            Monty game = new Monty(10, mockRandom);
            int doorToPick = 0;
            game.PickDoor(doorToPick);

            game.RevealDoors();

            Assert.True(game.Doors.Where(d => d.Revealed).Count() == 8);
        }
        [Fact]
        public void ContestantCanSwitchDoorWhenCarPicked()
        {
            Monty game = new Monty(3, mockRandom);
            Door firstDoorToPick = game.Doors[0];
            game.PickDoor(0);
            
            Assert.True(game.Doors[0].Picked == true);
            
            game.RevealDoors();
            
            Door secondDoorToPick = game.Doors.Single(d => d.Picked == false && d.Revealed == false);
            
            game.SwitchDoor();

            Assert.True(game.Doors.Where(d => d.Picked).Count() == 1);
            Assert.False(firstDoorToPick == secondDoorToPick);
        }
        [Fact]
        public void ContestantCanSwitchDoorWhenDudPicked()
        {
            Monty game = new Monty(3, mockRandom);
            Door firstDoorToPick = game.Doors[1];
            game.PickDoor(1);
            
            Assert.True(game.Doors[1].Picked == true);
            
            game.RevealDoors();
            
            Door secondDoorToPick = game.Doors.Single(d => d.Picked == false && d.Revealed == false);
            
            game.SwitchDoor();

            Assert.True(game.Doors.Where(d => d.Picked).Count() == 1);
            Assert.False(firstDoorToPick == secondDoorToPick);
        }
        [Fact]
        public void isWinReturnsTrueWhenContestantWins()
        {
            Monty game = new Monty(2);
            game.PickDoor(Array.IndexOf(game.Doors, game.Doors.Single(d => d.ContainsPrize == true)));
            Assert.True(game.IsWin());
        }
        
        [Fact]
        public void isWinReturnsFalseWhenContestantLose()
        {
            Monty game = new Monty(2);
            game.PickDoor(Array.IndexOf(game.Doors, game.Doors.Single(d => d.ContainsPrize == false)));
            Assert.False(game.IsWin());
        }
        
    }
}
