﻿using System.Windows;
using System.Windows.Input;

namespace Minesweeper
{
    public partial class MainWindow
    {
        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            PrepareGame();
            timer.Stop();
            Game.previousGame = Game.PreviousGame.NORMAL;
            TimeLabel.Content = "000";
        }

        private void NewGameMouseEnter(object sender, MouseEventArgs e)
        {
            switch (Game.previousGame)
            {
                case Game.PreviousGame.NORMAL:
                    Img.Set(NewGameButton, Img.NewGameMouseOver);
                    break;
                case Game.PreviousGame.WIN:
                    Img.Set(NewGameButton, Img.WinMouseOver);
                    break;
                case Game.PreviousGame.LOSE:
                    Img.Set(NewGameButton, Img.GameOverMouseOver);
                    break;
                default:
                    Img.Set(NewGameButton, Img.NewGameMouseOver);
                    break;
            }
        }

        private void NewGameMouseLeave(object sender, MouseEventArgs e)
        {
            switch (Game.previousGame)
            {
                case Game.PreviousGame.NORMAL:
                    Img.Set(NewGameButton, Img.NewGame);
                    break;
                case Game.PreviousGame.WIN:
                    Img.Set(NewGameButton, Img.Win);
                    break;
                case Game.PreviousGame.LOSE:
                    Img.Set(NewGameButton, Img.GameOver);
                    break;
                default:
                    Img.Set(NewGameButton, Img.NewGame);
                    break;
            }
        }
    }
}