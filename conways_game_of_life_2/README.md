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
* learnt from Minesweeper kata to eliminate duplication aggressively like x,y -> location, -> make sure tests not dependent on implementation details -> now getNeighbouringCells or whatever belongs in aptly named Location class instead of elsewhere
* Don't make things public unless necessary
* Tests should not break abstraction level
* Don't test implementation details (x has y)
* Should I keep threshold values in a file somewhere that the implementation and tests pull from?
* Think of BEHAVIOUR instead of shoehorning into inheritance

## Test Checklist
* World is all deadcells at the start
* World is not empty when there is any number of livingcells
* World size must be positive
* World looks at a coordinate and fetches neighbours

* Coordinate positions must be positive
* Coordinate by default contains a dead cell

* Living cell lives with 'nice' neighbourhood
* Living cell dies by underpopulation
* Living cell dies by overcrowding

* Dead cell revives with 'fertile' neighbourhood

* Input accepts text