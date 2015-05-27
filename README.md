`robot-explorer` is a .NET solution to the following programming challenge.

---
### CONTEXT:
A squad of robotic explorers are to be landed on the planet Venus.

The landing area is rectangular and must be navigated by the explorers 
so that their on-board cameras can get a complete view of the 
surrounding terrain to send back to Earth.

An explorer’s position and location is represented by a combination of `x` 
and `y` co-ordinates and a letter representing one of the four cardinal 
compass points. The landing area is divided up into a grid to simplify 
navigation. An example position might be `0, 0, N`, which means the 
explorer is in the bottom left corner and facing North.

In order to control an explorer, we send a simple string of letters. The 
possible letters are `L`, `R` and `M`. `L` and `R` makes the explorer 
spin 90 degrees left or right respectively, without moving from its 
current spot. `M` means move forward one grid point, and maintain the 
same heading.

Assume that the square directly North from `(x, y)` is `(x, y + 1)`.

### INPUT:
The first line of input is the upper-right coordinates of the landing 
area, the lower-left coordinates are assumed to be `0, 0`.

The rest of the input is information pertaining to the explorers that 
have been deployed. Each explorer has two lines of input. The first line 
gives the explorer’s position, and the second line is a series of 
instructions telling the explorer how to explore the plateau.

The position is made up of two integers and a letter separated by 
spaces, corresponding to the `x` and `y` co-ordinates and the explorer’s 
orientation.

Each explorer will be finished sequentially, which means that the second 
explorer won’t start to move until the first one has finished moving.

### OUTPUT:
The output for each explorer should be its final co-ordinates and heading.

---
### COMMAND LINE INPUT AND OUTPUT:
**Test Input:**
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

**Expected Output:**
1 3 N
5 1 E
