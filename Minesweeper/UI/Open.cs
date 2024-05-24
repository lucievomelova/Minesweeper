using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Minesweeper.CellState;

namespace Minesweeper
{
    /// <summary> handles cell opening </summary>
    public partial class MainWindow
    {
        /// <summary> open area of cells (when player clicks on number 0, the area around will open too) </summary>
        public static void OpenArea(Cell cell)
        {
            Queue<Cell> neighbourArea = new Queue<Cell>();
            neighbourArea.Enqueue(cell);       

            while (neighbourArea.Count > 0)
            {
                Cell current = neighbourArea.Dequeue();
                if (current.value == 0)
                {
                    foreach (Cell next in Neighbours.Get(current).Where(next => !next.isOpened && !next.IsMarked()))
                    {
                        neighbourArea.Enqueue(next);
                    }
                }
                current.CellState.LeftClick();
            }
        }

        /// <summary> When clicked cell is a mine, game ends </summary>
        public static void OpenMine()
        {
            timer.Stop();
            Img.Set(main.NewGameButton, Img.GameOver);

            Cell cell;
            for (int r = 0; r < Game.height; r++)
            {
                for (int c = 0; c < Game.width; c++)
                {
                    cell = Game.cells[r, c];
                    if (cell.IsMine())
                        cell.SetImage(Img.Mine);
                    else if(cell.isFlag)
                        cell.SetImage(Img.WrongMine);

                    DisableButton(cell.btn);
                }
            }
        }

        //user won, open whole field
        private static void OpenEverything()
        {
            foreach (Cell cell in Game.cells)
            {
                if(cell.value >= 0)
                    cell.SetImage(Img.Number(cell.value));
                else
                    cell.SetImage(Img.Flag);
            }
        }
    }
}