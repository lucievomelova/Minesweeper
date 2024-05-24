namespace Minesweeper.CellState;

/// <summary> State representing an unopened number cell. </summary>

public class NumberCellState : State
{
    public NumberCellState(Cell cell) : base(cell)
    {
    }

    public override void LeftClick()
    {
        cell.SetImage(Img.Number(cell.value));
        cell.isOpened = true;
        cell.CellState = new OpenCellState(cell);
    }

}