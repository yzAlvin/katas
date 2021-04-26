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

Your task is to impelment Conways Game of Life. You should be able to:
* Visualize the game in the console
* Be able to define how big the world/grid is (10x10, 50x80, etc.)
* Be able to set the inital state of the world

## Thoughts / Keep in mind

* Don't make things public for no reason
* Tests should not break abstraction level
* Tests should contain no logic
* Don't test implementation details
* Think in terms of **BEHAVIOUR** - put on "tester" hat

* Trying to be as "functional" as possible
    * Pure functions
    * No side effects - might be hard, still unsure how to handle input/output streams
    * Writing small methods and combining them
    * Preferring Linq methods over loops - preferring declarative over imperative

## Approaches

### Adding 3D Conways
* In a 3D world rules remain the same except you can have neighbours on either side.
    * Method for getting neighbours is different but everything else remains the same, 

* Turn Location into an interface/abstract class, have a Location2D and a Location3D. World would now need "depth" as an additional parameter for Locations.
* Turn World into interface/abstract class, have a World2D and a World3D. Only World3D would have "depth". Would also need a new Location that uses this "depth" so I would also need a Location2D and a Location3D.

* Add "depth" into World, and defaulting depth of a 2D locations to 1. 

// cheated writing tests for 3D couldn't work out the wrapping on paper
 
**Give a high level view of my solution**

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

* Pause between each generation

### Interfaces
* World(int width, int height, List<(int x, int y)> liveCells)
* World.NextWorld() => World
* World.IsEmpty() => bool
* <s>World.SetLivingAt(Location location)</s>

* Location(int x, int y)
* Location.BecomeAlive()
* Location.BecomeDead()
* Location.Neighbours() => List<Location>
* Location.WrapLocation(int width, int height) => Location

* Cell()
* Cell.AliveNextGeneration(int numberOfNeighbours) => bool

* WorldRenderer
* WorldRenderer.RenderWorld(World world) => string

### Test Cases
* World is empty when there are 0 living cells
* World is not empty when there is any number of living cells
* World size must be positive
* World size must be less than 100
* <s>World should set a Location to have a living cell</s>
* World should calculate the next generation

* Location positions must be positive
* Location can become a live cell or a dead cell
* Location can return the expected neighbouring locations
* Location can be wrapped based on a max size

* Living cell lives with 2 neighbours
* Living cell lives with 3 neighbours
* Living cell dies with less than 2 neighbours
* Living cell dies with more than 3 neighbours
* Dead cell revives with 3 neighbours

* WorldRenderer returns world in string format