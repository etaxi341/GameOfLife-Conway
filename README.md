# Conway's Game Of Life by Maximilian Engel

A small project for a contest on IT-Talents.de about Conway's Game Of Life

### What is Conway's Game Of Life?

You can find more about Conway's Game Of Life [here](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)

## Installation

### 1. Download

Download the .exe [here](https://github.com/etaxi341/GameOfLife-Conway/releases).

### 2. Installing

* Make sure that you have .NET Framework 4.5 installed (You probably have this installed already)
* Extract the .zip file into a new folder
* Execute .exe file

### 3. Fix Crashes

If any crashes occur try this:
* Use the Program in a different Folder (Some Anti-Virus Softwares don't like my Program on Desktop and sometimes in Documents)
* Execute as Admin

## How to use the Program

<img align="left" src="https://i.imgur.com/m1w5SHU.png">

### Symbols:

<img align="left" src="https://i.imgur.com/Ziou3Gf.png">
Open any image and render it as living and dead cells. Images bigger than 512x512 will be downscaled

<img align="left" src="https://i.imgur.com/bM78t4X.png">
Save the current grid as Bitmap. You can reopen it later on with "Open Image"

<img align="left" src="https://i.imgur.com/ev2Rh5s.png">
Start/Stop the simulation of the Grid

<img align="left" src="https://i.imgur.com/QHBDe26.png">
Simulate one Frame of the Grid

<img align="left" src="https://i.imgur.com/rGkqr54.png">
Delay between the simulation cycles (50 = 50ms delay between cycles)

<img align="left" src="https://i.imgur.com/qlQTkrD.png">
Size of the new Grid (when generating a new one)

<img align="left" src="https://i.imgur.com/5GwrbF5.png">
Generate a new random Grid with the above defined size

<img align="left" src="https://i.imgur.com/nxD6UMw.png">
Generate a new blank Grid with the above defined size

<img align="left" src="https://i.imgur.com/ulE3I8n.png">
Draw on the grid with a 1x1 Brush (Left-click = living cell --- Right-click = dead cell)

<img align="left" src="https://i.imgur.com/HoTiOyB.png">
Select cells on the grid to copy them later as pattern

<img align="left" src="https://i.imgur.com/0XLdj5n.png">
Use one of the pre-defined patterns on the grid

<img align="left" src="https://i.imgur.com/pKvyMZL.png">
Add a new Pattern to the Tool Box

<img align="left" src="https://i.imgur.com/trfih7q.png">
Change the color of living and dead cells


## Features

* Play Button (Run the simulation)
* Next Frame (Simulate one Cycle)
* Import Image (Imports an .jpg, .png or. bmp to the grid [Everything bigger than 512px in one direction will be downscaled])
* Save Image (Saves the Simulation at its current state as .bmp)
* Create Random Image (Creates noisy grid)
* Create Blank Image (Just an empty grid)
* Drawing (Leftclick: Alive Cell --- Rightclick: Dead Cell)
* Drawing Lines (Hold Ctrl while drawing to draw straight lines)
* Instantiate Patterns on the grid
* Add your own custom Patterns
* Set Alive and Dead Color
* Change Pattern rotation with arrow keys (right,left)
* Move the Grid when holding Middle Mouse Button down
* Select Cells on the Grid and use them as a pattern

## Built With

* [Visual Studio 2017 Community](https://www.visualstudio.com/de/vs/whatsnew/) - Development Environment
* [.NET Framework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=30653) - Framework

## Versioning

You can find all the uploaded versions of this program [here](https://github.com/etaxi341/GameOfLife-Conway/releases). 

## Authors

* **Maximilian Engel** - *Initial work* - [etaxi341](https://github.com/etaxi341)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
