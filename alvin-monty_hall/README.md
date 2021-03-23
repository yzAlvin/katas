# Monty Hall Kata

## Description
* A big prize is hidden behind one of three doors
* The contestant picks a door
* The host reveals one of the two doors that the contestant did not pick to reveal a dud
* Should the contestant keep or switch doors?
* Write a computer simulation that will prove switching is best
* Simulate 1000 games using each strategy

## Test Checklist
* <s>Doors have a prize property</s>  *This is the same as the test underneath*
* Door's prize property can either be a win or lose (true, or false)
* <s>Door's prize property cannot be changed once it has been instatiated</s>
* When creating multiple doors only one will be a 'win' (true)
* The door with the 'win' (true) is selected at random
* Contestant can pick a door
* Host reveals a door with the dud from the unpicked doors - when contestant has not picked the winning door
* Host reveals a door with the dud from the unpicked doors - when contestand has picked the winning door
* Contestant can stick with their door
* Contestant can switch their door
* Contestant wins if picked door is door with prize

## Images of the simulation
3 Doors over 10000 Simulations
![3 Doors Simulation](/Simulate3Doors.png)

100 Doors over 10000 Simulations
![100 Doors Simulation](/Simulate100Doors.png)
