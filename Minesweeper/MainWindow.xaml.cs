using System.Windows;

namespace Minesweeper
{
    /// <summary> Interaction logic for MainWindow.xaml </summary>
    public partial class MainWindow
    {
        public static Timer timer;

        private static MainWindow main;

        public MainWindow()
        {
            InitializeComponent();
            PrepareGame();
            timer = new Timer(this);
            main = this;
        }

        
        // draw game field, set buttons, resize window...
        public void PrepareGame()
        {
            Initialize();
            CreateGrid();
            CreateBtns();
            Img.Set(NewGameButton, Img.NewGame);

            SizeToContent = SizeToContent.WidthAndHeight;
        }
        
        private void OpenOptions(object sender, RoutedEventArgs e)
        {
            Options options = new Options(this);
            options.Show();
        }
        
        private void OpenLeaderboard(object sender, RoutedEventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.Show();
        }

    }
}