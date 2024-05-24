namespace Minesweeper.CellState;

/// <summary> State representing an unopened mine cell. </summary>

public class MineCellState : State
{
    public MineCellState(Cell cell) : base(cell)
    {
        cell.value = Values.MINE;
    }

    public override void LeftClick()
    {
        if (cell.isFlag || cell.isQuestionMark)  // click doesn't have any effect
            return;

        cell.CellState = new WrongMineCellState(cell);
    }
}