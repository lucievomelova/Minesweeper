﻿using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    /// <summary> pre-solves area around open cells in current game (if possible) </summary>
    public class Solver
    {
        public readonly Model model;

        public Solver()
        {
            model = new Model();
        }

        /// <summary> count unopened but known numbers in game field </summary>
        public int KnownNumbers() //
        {
            return MainWindow.cells.Cast<Cell>().Count(c => c.IsNumber() && !c.isOpened && c.isKnown);
        }

        /// <summary> find every opened nonzero number and try to update it. If a number is updated, it's neighbours
        /// are put in the queue again and UpdateCell() will be ran on them again. </summary>
        public void Update()
        {
            Queue<Cell> BorderArea = new Queue<Cell>();
            foreach (Cell c in MainWindow.cells)
                if (c.IsNumber() && c.minesLeft != 0 && c.isOpened)
                    BorderArea.Enqueue(c);

            while (BorderArea.Count > 0)
            {
                Cell next = BorderArea.Dequeue();
                bool updated = UpdateCell(next);
                if (!updated) continue;
                
                foreach (Cell neighbour in Neighbours.Get(next))
                    if (neighbour.isOpened && neighbour.unknownLeft != 0)
                        BorderArea.Enqueue(neighbour);
            } 
            
            model.placeMines.TryAll();
        }

        /// <summary> Count known mines and unknown cells around cell. If number of known mines == cell.value or
        /// number of unknown cells == cell.value, all remaining neighbours are known.  </summary>
        /// <returns> Returns true if new known cells were found.</returns>
        public bool UpdateCell(Cell cell)
        {
            //if (cell.IsMarked()) return false;

            //true if cell will be updated
            bool updated = cell.minesLeft != cell.value - Neighbours.CountKnownMines(cell) || 
                           cell.unknownLeft != Neighbours.CountUnknown(cell);
            
            cell.minesLeft = cell.value - Neighbours.CountKnownMines(cell); //subtract number of found mines
            cell.unknownLeft = Neighbours.CountUnknown(cell); //number of empty places

            if (cell.minesLeft != cell.unknownLeft && cell.minesLeft != 0) return updated;
            
            foreach (Cell neighbour in Neighbours.Get(cell))
            {
                if (neighbour.isKnown) continue;
                
                if(MainWindow.DebugMode && !neighbour.IsMarked())
                    neighbour.SetImage(Img.Known);
                
                neighbour.isKnown = true;
            }

            Values.minesLeft -= cell.minesLeft;
            cell.minesLeft = 0;
            cell.unknownLeft = 0;
            return updated;
        }

        public int CountIncorrectFlags()
        {
            int counter = 0;
            foreach (Cell cell in MainWindow.cells)
            {
                if (cell.isFlag && !cell.IsMine())
                    counter++;
            }

            return counter;
        }
    }
}