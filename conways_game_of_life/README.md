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
* Minesweeper kata was good, now I know to eliminate duplication aggressively like x,y -> location, now getNeighbouringCells or whatever belongs in Location class instead of Field or whatever.
* Don't make things public unless necessary
* Think extensibility - tests should not break abstractions
* Don't test implementation details (x has y)
* Try extra hard not to code anything unless I have written a test for it
* Should I keep threshold values in a file somewhere that the implementation and tests pull from?


## Test Checklist
* 