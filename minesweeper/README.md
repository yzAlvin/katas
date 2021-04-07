# Minesweeper Kata

Well, the goal of the game is to find all the mines within an MxN field. To help you, the game shows a number in a square which tells you how many mines there are adjacent to that square. For instance, take the following 4x4 field with 2 mines (which are represented by an * character):

~~~
*... 
.... 
.*.. 
....
~~~

The same field including the hint numbers described above would look like this:

~~~
*100 
2210 
1*10 
1110
~~~

You should write a program that takes input as follows:

* The input will consist of an arbitrary number of fields.   
* The first line of each field contains two integers n and m (0 < n,m <= 100) which stands for the number of lines and columns of the field respectively.   
* The next n lines contains exactly m characters and represent the field.  
* Each safe square is represented by an “.” character (without the quotes) and each mine square is represented by an “*” character (also without the quotes).  
* The first field line where n = m = 0 represents the end of input and should not be processed.  

Your program should produce output as follows: 

For each field, you must print the following message in a line alone:  

Field #x:

Where x stands for the number of the field (starting from 1). 

The next n lines should contain the field with the “.” characters replaced by the number of adjacent mines to that square. There must be an empty line between field outputs.

This is the acceptance test input:

~~~
44 
*... 
.... 
.*.. 
....
~~~

~~~
35 
**... 
..... 
.*...
~~~

~~~
00
~~~

and output:

~~~
Field #1: 
*100 
2210 
1*10 
1110
~~~

~~~
Field #2: 
**100 
33200 
1*100
~~~

## Thoughts

* <s>I am going to try a top-down approach because I have never tried a top down approach, and maybe I well see how to use mocking for lower-level stuff?</s>
* No idea what I'm doing

* Read in from file
* Read in from console
* Reading in the M x N will create a new char[,] 2d array of chars..
* Then it will go through each line and populate the 2d array with '*' and '.'
* Need to be able to check neighbour cells
* Need to be able to change '.' to a number, I don't want to do something like cell.value = 0, "reaching in and changing it's guts", instead, do something like cell.Calculate() which will do it for me.
* Fields are made up of cells

## Test Checklist
------------------------------

* Creates the M x N 2d array
* Populates the array
------------------------------

* Checks neighbour cells:
    * Corners, where there are only 3 available cells
    * Edges, where there are only 5 available cells, unless it is a corner
    * Everywhere else, where there are 8 available cells
* Cells have a position (x, y) on the 2d array, that cannot be negative
* Cells start off without a mine (safe)
--------------------------------

* Field therefore starts off without mines
* Field class sets where the mines are
* Field can calculate list of neighbour cells
--------------------------------

* Input can take in dimensions
* Input can parse the dimensions up to 99 (highest size)
--------------------------------

* Output can parse field to calculate number of mines
* Output can print to console
--------------------------------