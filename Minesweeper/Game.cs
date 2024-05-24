﻿using System.Windows.Controls;

namespace Minesweeper
{

    public enum Difficulty
    {
        Beginner,
        Intermediate,
        Expert
    }
    public static class Game
    {
        /// <summary> how many cells (buttons) aren't opened (including marked cells) </summary>
        public static int unopenedLeft;

        /// <summary> how many flags (to mark mines) aren't placed yet </summary>
        public static int flagsLeft;

        /// <summary> number of columns </summary>
        public static int width = 9;

        /// <summary> number of rows </summary>
        public static int height = 9;

        /// <summary> total number of mines in current game </summary>
        public static int mines = 10;

        public static Difficulty difficulty = Difficulty.Beginner;

        public static Cell[,] cells;

        /// <summary> State of previous game - if it was lost or won or if it wasn't neither of those two </summary>
        public enum PreviousGame
        {
            NORMAL, //last game was ended before player won or lost (this is also the state after app start)
            WIN, //player won last game
            LOSE //player lost last game
        }
        
        private static PreviousGame _previousGame = PreviousGame.NORMAL;

        public static PreviousGame previousGame
        {
            get { return _previousGame;  }
            set
            {
                _previousGame = value;
                if (_previousGame == PreviousGame.LOSE)
                {
                    MainWindow.OpenMine();
                }
            }
        }

        /// <summary> find cell which is represented by button *btn* </summary>
        public static Cell FindCell(Button btn)
        {
            for (int r = 0; r < height; r++)
            for (int c = 0; c < width; c++)
                if (cells[r, c].btn == btn) return cells[r, c];
            
            return null;
        }
        
        /// <summary> Count all incorrectly placed flags on the game field </summary>
        public static int CountIncorrectFlags()
        {
            int counter = 0;
            foreach (Cell cell in cells)
            {
                if (cell.isFlag && !cell.IsMine())
                    counter++;
            }

            return counter;
        }
    }
}