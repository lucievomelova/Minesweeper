using System;
using System.Windows;
using Minesweeper.CellState;

namespace Minesweeper
{
    /// <summary> class for generating game field </summary>
    public static class GameGenerator
    {
        /// <summary> generate new game field </summary>
        public static void Generate(Cell cell)
        {
            for (int r = 0; r < Game.height; r++)
            {
                for (int c = 0; c < Game.width; c++)
                {
                    Game.cells[r, c].value = Values.UNKNOWN;
                }
            }
            cell.value = 0;
            cell.CellState = new NumberCellState(cell);
            SetNeighboursToKnown(cell.row, cell.column);
            PlaceRemainingMines(Game.mines);
            SetNumbersAroundMines();
        }

        
        /// <summary> place remaining mines randomly in game field </summary>
        private static void PlaceRemainingMines(int numberOfMines)
        {
            Random random = new Random();
            int minesPlaced = 0;
            while(minesPlaced < numberOfMines)
            {
                int r = random.Next(0, Game.height);
                int c = random.Next(0, Game.width);
                Cell cell = Game.cells[r, c];
                if (!cell.isOpened && cell.value == Values.UNKNOWN)
                {
                    minesPlaced++;
                    cell.CellState = new MineCellState(cell);
                }
            }
        }
        
        /// <summary> when all neighbours are known. Used in the beginning, because first
        /// number is always 0, so all cells around must be numbers. </summary>
        private static void SetNeighboursToKnown(int row, int column)
        {
            int[] arr = {-1, 0, 1};
            foreach (int r in arr)
                foreach (int c in arr)
                if (Values.InBounds(row + r, column + c) && !Game.cells[row + r, column + c].IsMine())
                {
                    Cell cell = Game.cells[row + r, column + c];
                    cell.value = Values.NUMBER;
                }
        }

        // mines are placed, now place numbers in the game field
        private static void SetNumbersAroundMines()
        {
            for (int r = 0; r < Game.height; r++)
            {
                for (int c = 0; c < Game.width; c++)
                {
                    Cell cell = Game.cells[r, c];
                    if(cell.IsMine() || cell.isOpened) continue;
                    
                    int number = Neighbours.CountMines(cell);
                    cell.value = number;
                    cell.CellState = new NumberCellState(cell);
                }
            }
        }
    }
}