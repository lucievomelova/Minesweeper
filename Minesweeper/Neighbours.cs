﻿using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    /// <summary> all methods here work with cell's neighbours  </summary>
    public static class Neighbours
    {
        /// <summary> get cell neighbours - cells that share an edge or a corner with *cell*</summary>
        /// <returns> list of neighbours </returns>
        public static List<Cell> Get(Cell cell)
        {
            List<Cell> neighbours = new List<Cell>();
            int[] arr = {-1, 0, 1};
            foreach (int r in arr)
                foreach (int c in arr)
                {
                    if (r == 0 && c == 0) continue;
                    if (Values.InBounds(cell.row + r, cell.column + c))
                        neighbours.Add(Game.cells[cell.row + r, cell.column + c]);
                }
            return neighbours;
        }
       
        public static void PressDown(Cell cell)
        {
            if(cell.value == CountFlags(cell))
                foreach (Cell neighbour in Get(cell))
                    if(!neighbour.isOpened && !neighbour.IsMarked())
                        neighbour.SetImage(Img.EmptyMouseOver);
        }
        
        public static int CountMarkedMines(Cell cell)
        {
            return Get(cell).Count(h => h.value == Values.MINE && h.isFlag);
        }

        public static int CountMines(Cell cell)
        {
            return Get(cell).Count(h => h.value == Values.MINE);
        }
        
        public static int CountFlags(Cell cell)
        {
            return Get(cell).Count(h => h.isFlag);
        }
    }
}