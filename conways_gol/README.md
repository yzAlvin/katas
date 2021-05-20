# Conway's Game of Life

"Life" is a zero-player game devised by John Horton Conway. One interacts with the game by creating an initial configuration and observing how it evolves.

## Rules

The universe of the Game of Life is a two-dimensional grid of cells, each of which is in one of two possible states, alive or dead.

If the cell is on the edge of the grid it wraps around to the other side.

At each tick, the following occurs:
* **Underpopulation** &rarr; Any live cell with < 2 live neighbours dies.
* **Overcrowding** &rarr; Any live cell with > 3 live neighbours dies.
* **Survival** &rarr; Any live cell with 2 or 3 live neighbours lives
* **Reproduction** &rarr; Any dead cell with exactly 3 live neighbours becomes alive

## Task

Your task is to implement Conways Game of Life. You should be able to:
* Visualize the game in the console
* Be able to define how big the world/grid is (10x10, 50x80, etc.)
* Be able to set the inital state of the world

## Stuff I kept in mind during the kata

* Don't make things public for no reason
* Tests should not break abstraction level
* Tests should contain no logic
* Don't test implementation details
* Think in terms of **BEHAVIOUR** - put on "tester" hat

* Try to be "functional" 
    * Pure functions
    * No side effects - might be hard, still unsure how to handle input/output streams, exception monad?
    * Writing small methods and composing them 
    * Preferring Linq methods over loops 

## Before Coding

### Scenarios
* Live -> Live
* Live -> Dead
* Dead -> Live
* Dead -> Dead

* Cell on edge of game
* Cell not on edge of game

* Display world from console
* Display world from file

### Interfaces
* WorldSize(int width, int height, int depth)

* World(WorldSize worldSize, Location[] liveCells)
* World.NextWorld() => World
* World.IsEmpty() => bool
* World.IsStagnant() => bool
* <s>World.SetLivingAt(Location location)</s>

* Location(int x, int y)
* Location.BecomeAlive()
* Location.BecomeDead()
* Location.Neighbours() => List<Location>
* Location.WrapLocation(WorldSize worldSize) => Location

* Cell()
* Cell.AliveNextGeneration(int numberOfNeighbours) => bool

* WorldRenderer
* WorldRenderer.RenderWorld(World world) => string

### Test Cases
* World size must be positive
* World size must be less than 100

* World is empty when there are 0 living cells
* World is not empty when there is any number of living cells
* World is stagnant when next world is identical to current world
* World is not stagnant when next world is different to current world
* <s>World should set a Location to have a living cell</s>
* World should calculate the next generation

* Location can be a living cell
* Location can be a dead cell
* Location can return the expected neighbouring locations
* Location can be wrapped based on some upper bound

* Living cell lives with 2 neighbours
* Living cell lives with 3 neighbours
* Living cell dies with less than 2 neighbours
* Living cell dies with more than 3 neighbours
* Dead cell revives with 3 neighbours

* WorldRenderer returns world in string format

### Class Diagram
![Class Diagram](https://user-images.githubusercontent.com/14051545/116186262-9ef08e00-a766-11eb-9d5e-56ebe26cc5f4.jpg)

## Extensions

### More User Friendly Conways

Allows a more user friendly version of Conways
* Allow world state to be saved and loaded from disk
* Allow users to customize the world state on startup

* System.IO has a method public static void WriteAllText (string path, string? contents); 
    * Could write each generation to a file 0.txt, 1.txt, etc.

* Instead of Console.In for input, use FileReader, both are StreamReaders with ReadLine() method.

* Users already customise the world state on startup.

### Support two user interfaces

If the initial Conways had only one user interface (i.e., command line), write a version of Conways that supports two interfaces (i.e., command line and web application).

Make sure that one interface is event-driven (i.e., web) and another is loop-driven (i.e., command line).

This becomes the perfect opportunity to teach about abstraction of a view layer and "Tell Don't Ask."

* Maybe after I learn more about web applications

### 3D Conways

At the beginning of a game you should be able to determine whether you want to work in a 3D or 2D world. The rules remain the same except in a 3D world you can have neighbors on either side.

* Location -> Location2D and Location3D. World would now need "depth" as an additional parameter for Location3D, depth of a Location2D is just 1.

* World -> World2D and World3D, all methods would be same except constructor. The Locations list would contain Location2D and Location3D respectively.
