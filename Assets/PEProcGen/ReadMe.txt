PEProcGen for Unity v 0.5

PEProcGen does the following:

1) Creates procedurally generated 2D terrains
2) Currently creates caves and rooms
3) In the future may create landscapes...

Here's the process:

Create a Unity Project 
Import the PEProcGen package
Create an empty GameObject
Add a TerrainRenderer Script
Add a CaveGenerator/RoomGenerator Script
In TerrainRenderer:
	1) Set the Tile Sets Size to at least 1
	2) Set the Tile Data Size to at least 2
	3) Drag a sprite into each of the 2 elements

Click Generate in the CaveGenerator/RoomGenerator

See the Demo_Simple/MainScene scene for a scripting example
 