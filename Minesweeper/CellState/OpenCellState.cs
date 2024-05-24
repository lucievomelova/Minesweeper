namespace Minesweeper.CellState;

/// <summary> State representing an opened cell. </summary>

public class OpenCellState : State
{
    public OpenCellState(Cell cell) : base(cell)
    {
        cell.isOpened = true;
        Game.unopenedLeft--;
    }

    public override void LeftClick()
    {
        // if a correct number of flags is around an opened number cell, the player
        // can click on the cell and all remaining neighbours will be opened. Otherwise nothing happens.

        if (Neighbours.CountFlags(cell) != cell.value) return;  // not enough flags
            
        foreach (Cell neighbour in Neighbours.Get(cell))
        {
            if (neighbour.IsMarked() || neighbour.isOpened) 
                continue;
            if(neighbour.value == 0) 
                MainWindow.OpenArea(neighbour);
            else
            {
                neighbour.CellState.LeftClick();
            }
        }
    }

    public override void RightClick()
    {
        return;  // right click doesn't do anything
    }
}