using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Minesweeper.CellState;

namespace Minesweeper
{
    public enum BruteForceState
    {
        MINE, 
        NUMBER, 
        UNKNOWN,
        NONE
    }
    
    public class Cell
    {
        public int row;

        public int column;
        
        /// <summary> cell value - either a number (0-8) or a mine (Values.MINE) </summary>
        public int value;
        
        /// <summary> true if cell is opened </summary>
        public bool isOpened;

        /// <summary> true if cell is still closed and it's marked with a flag </summary>
        public bool isFlag;

        /// <summary> true if cell is still closed and it's marked with a question mark </summary>
        public bool isQuestionMark;

        /// <summary> corresponding Button on the game field </summary>
        public readonly Button btn;
        public State CellState;

        public Cell(int row, int column)
        {
            this.row = row;
            this.column = column;
            value = Values.UNKNOWN;
            isOpened = false;
            isFlag = false;
            isQuestionMark = false;
            btn = new Button();
            CellState = new UnknownCellState(this);
        }
        
        public void SetImage(BitmapImage img) { Img.Set(btn, img); }

        public bool IsMine() { return value == Values.MINE; }

        public bool IsNumber() { return value  >= 0; }

        public bool IsMarked() { return isFlag || isQuestionMark; }
    }
}