using System.Windows;

namespace Minesweeper.CellState;

/// <summary> State representing an unknown cell. Cells are unknown before game start. </summary>


public class UnknownCellState : State
{
    public UnknownCellState(Cell cell) : base(cell)
    {
        cell.isOpened = false;
        cell.value = Values.UNKNOWN;
    }

    public override void LeftClick()
    {
        MainWindow.timer.Start();
        GameGenerator.Generate(cell); //generate new game field
        MainWindow.OpenArea(cell); //open clicked cell (there will always be number 0, so area will be opened)
        
    }
}