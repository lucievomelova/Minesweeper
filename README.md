# Minesweeper
Implementation of the classic Minesweeper game.

# How to play
Start new game by left clicking anywhere on the game field. A part of the game field 
will open. Then, you can start marking mines on the game fields by right clicking 
on a chosen cell. You can open cells with a left click. 

Each opened number will have a value from 1 - 8. This value indicates how 
many mines are around it. Once you mark the correct number of mines around, you 
can left click on the number and all remaining neighboring cells around it 
will open.

Once you begin a new game, a timer will start. If you finish a game successfully,
you will be asked to enter your name and your game will be saved to the leaderboard.

## Before start
Before starting a new game, you can select game difficulty. This can be 
done in the *Options* menu. Remember, that once you change difficulty 
and confirm your choice, new game will start.

### Difficulties
There are three difficulties - Beginner, Intermediate and Expert. A player can 
choose difficulty in the *Options* menu. 

## Leaderboard
Each successfully finished game is saved to leaderboard - with players name and the 
time it took them to finish the game. Leaderboard can be displayed by clicking on 
*Leaderboard* in the menu and then selecting wanted difficulty.

# Technical details
This application is written in C#, in WPF. The game field is stored as an array of cells. 
Once the game starts, a game field is generated, where each cell is either a number 
(0-8), or a mine. 

## MainWindow class
This class represents the main game window. It contains methods for game start, game 
end, mouse events (either for cells or new game button) and functionalities for when game 
starts or ends. It is split into many files - `MainWindow.cs` and all files in the `UI`
directory.

## Game.cs
Static class `Game.cs` contains information about current game. 
It is a static class, because only one game exists at a time. It contains variables, 
that are needed for the game calculations:
* `int flagsLeft` - how many flags haven't been placed yet
* `int width` - game field width
* `int height` - game field height
* `int mines` - number of mines that the game field contains
* `Difficulty difficulty = Difficulty.Beginner` - game difficulty
* `GameMode gameMode = GameMode.Help` - game mode

The most important attribute is the array of cells `cells`, that is the actual 
game field:
* `Cell[,] cells`

## Cell.cs
Each cell is a `Cell` object. The code for that can be found in file `Cell.cs`. 
It has attributes, that contain its `value` and position (`row`, `column`). 
Some determine whether the cell is opened (`isOpened`), a flag (`isFlag`), 
then how many mines are around it and other needed information.

## GameGenerator.cs
Contains methods for generating the game field.

### Generating
Generating occurs at game start. Player clicks on a cell, this cell then has to 
be number 0, so at least a small part of game field is opened and not just one number.
This cell is set to zero and then all mines are placed randomly. After that, 
numbers are placed around them.

## Other classes and files
The application consists of many other classes and files.
* `Neigbours.cs` - contain methods working with cell neighbors
* `Img.cs` - setting cell images
* `Open.cs` - opening cell after click 
* `Options.cs` - options menu
* `Leaderboard.cs` - window class for displaying leaderboard
* `Win.cs` - window that appears after winning a game
* `Timer.cs` - timer class
* `Values.cs` - game constants

# Installation
The game was developed and tested on Windows. There are executables
provided in `Minesweeper/bin/Debug` and `Minesweeper/bin/Release` 
directories. But if the provided executables do not work on your 
computer, you can also compile the project yourself and run it 
that way. 