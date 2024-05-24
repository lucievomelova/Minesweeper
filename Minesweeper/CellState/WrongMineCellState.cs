namespace Minesweeper.CellState;

/// <summary> State representing an opened cell that is a mine -> so game over. </summary>
public class WrongMineCellState : State
{
    public WrongMineCellState(Cell cell) : base(cell)
    {
        Game.previousGame = Game.PreviousGame.LOSE;  // game over
        cell.SetImage(Img.MineClicked);
    }

    public override void LeftClick()
    {
        return; // nothing happens, game field is disabled
    }
}