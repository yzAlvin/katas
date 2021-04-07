using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

namespace monty_hall
{
    public class Monty
    {
        public Door[] Doors { get; set; }

        public Monty(int numberOfDoors)
        {
            this.Doors = new Door[numberOfDoors];
            GenerateDoors(numberOfDoors, RandomlySelectDoorWithPrize(numberOfDoors));
        }

        public Monty(int numberOfDoors, GetRandomNumber randomNumberGenerator)
        {
            this.Doors = new Door[numberOfDoors];
            GenerateDoors(numberOfDoors, RandomlySelectDoorWithPrize(numberOfDoors, randomNumberGenerator));
        }
        
        public int RandomlySelectDoorWithPrize(int numberOfDoors)
        {
            GetRandomNumber randomNumberGenerator = new GetRandomNumber(new Random());
            int doorWithPrizeNumber = randomNumberGenerator.getRandomInt(0, numberOfDoors);
            return doorWithPrizeNumber;
        }

        public int RandomlySelectDoorWithPrize(int numberOfDoors, GetRandomNumber randomNumberGenerator)
        {
            int doorWithPrizeNumber = randomNumberGenerator.getRandomInt(0, numberOfDoors);
            return doorWithPrizeNumber;
        }

        private void GenerateDoors(int numberOfDoors, int doorWithPrizeNumber)
        {
            for (var doorNumber = 0; doorNumber < numberOfDoors; doorNumber++)
            {
                if (doorNumber == doorWithPrizeNumber)
                {
                    this.Doors[doorNumber] = new Door(true);
                }
                else
                {
                    this.Doors[doorNumber] = new Door(false);
                }
            }
        }

        public void PickDoor(int doorToPick)
        {
            this.Doors[doorToPick].Picked = true;
        }

        public void RevealDoors()
        {
            var doorsToReveal = this.Doors.Where(d => d.Picked == false && d.ContainsPrize == false);

            bool doesPickedDoorContainPrize = this.Doors.Single(d => d.Picked == true).ContainsPrize == true;
            if (doesPickedDoorContainPrize)
            {
                foreach (Door d in doorsToReveal.Skip(1))
                {
                    d.Revealed = true;
                }
            }
            else
            {
                foreach (Door d in doorsToReveal)
                {
                    d.Revealed = true;
                }
            }
        }

        public void SwitchDoor()
        {
            var doorToSwitchTo = this.Doors.Single(d => d.Picked == false && d.Revealed == false);
            var currentlyPickedDoor = this.Doors.Single(d => d.Picked == true);
            doorToSwitchTo.Picked = true;
            currentlyPickedDoor.Picked = false;
        }

        public bool IsWin()
        {
            var winningDoor = this.Doors.Single(d => d.ContainsPrize == true);
            var pickedDoor = this.Doors.Single(d => d.Picked == true);
            return winningDoor == pickedDoor;
        }
    }
}