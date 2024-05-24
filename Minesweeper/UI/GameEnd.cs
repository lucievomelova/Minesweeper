using System.Windows.Controls;

namespace Minesweeper
{
    public partial class MainWindow
    {
        /// <summary> check if player has already won the game - either all mines are marked with a flag or the number of
        /// unopened cells is equal to number of mines in game </summary>
        public static void CheckWin()
        {
            if ((Game.CountIncorrectFlags() == 0 && Game.flagsLeft == 0) ||
                Game.unopenedLeft == Game.mines)
                Win();
        }

        private static void Win()
        {
            timer.Stop();
            OpenEverything();
            Game.previousGame = Game.PreviousGame.WIN;
            foreach (Cell c in Game.cells)
            {
                DisableButton(c.btn);
                if (c.IsMine())
                    c.SetImage(Img.Flag);
            }
            main.MinesLeftLabel.Content = 0;
            Img.Set(main.NewGameButton, Img.Win);
            
            Win winWindow = new Win(timer.TimePassed());
            winWindow.Show();
        }

        private static void DisableButton(Button btn)
        {
            btn.MouseRightButtonUp -= RightClick;
            btn.MouseEnter -= BtnMouseEnter;
            btn.MouseLeave -= BtnMouseLeave;
            btn.PreviewMouseLeftButtonDown -= BtnMouseDown;
            btn.PreviewMouseLeftButtonUp -= BtnMouseUp;
        }
    }
}