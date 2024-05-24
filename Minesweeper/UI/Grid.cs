using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minesweeper
{
    public partial class MainWindow
    {
        /// <summary> left mouse button is pressed down </summary>
        private static void BtnMouseDown(object sender, MouseEventArgs e)
        {
            BtnMouseEnter(sender, e);
            Cell cell = Game.FindCell((Button) sender); //mouse cursor is over this cell
            if (cell.value > 0 && cell.value - Neighbours.CountMarkedMines(cell) == 0)
                Neighbours.PressDown(cell);
        }

        /// <summary> left mouse button is released </summary>
        private static void BtnMouseUp(object sender, MouseEventArgs e)
        {
            Cell cell = Game.FindCell((Button) sender); //mouse cursor is over this cell
            cell.CellState.LeftClick();
            if (Game.previousGame != Game.PreviousGame.LOSE)
                BtnMouseLeave(sender, e);

            cell.CellState.LeftClick();
            CheckWin();
        }

        private static void BtnMouseEnter(object sender, MouseEventArgs e)
        {
            Cell cell = Game.FindCell((Button) sender);
            if (!cell.isOpened && !cell.IsMarked())
                cell.SetImage(Img.EmptyMouseOver);
        }

        private static void BtnMouseLeave(object sender, MouseEventArgs e)
        {
            Cell cell = Game.FindCell((Button) sender);
            if (!cell.isOpened && !cell.IsMarked())
                Img.Set(cell.btn, Img.Empty);
        }


        /// <summary> right mouse button is clicked </summary>
        private static void RightClick(object sender, RoutedEventArgs e)
        {
            Cell cell = Game.FindCell((Button) sender);
            cell.CellState.RightClick();
            main.MinesLeftLabel.Content = Game.flagsLeft;  // update flag counter
            CheckWin();
        }
    }
}