namespace Minesweeper.CellState;

/// <summary> Possible states: unknown, mine, number, open. </summary>

public abstract class State
{
    protected Cell cell;

    public State(Cell cell)
    {
        this.cell = cell;
    }

    public virtual void RightClick()
    {
        if (cell.isFlag)
        {
            cell.SetImage(Img.QuestionMark);
            ++Game.flagsLeft;  // increment flag counter
            cell.isFlag = false;
            cell.isQuestionMark = true;
        }
        else if (cell.isQuestionMark)
        {
            Img.Set(cell.btn, Img.Empty);
            cell.isQuestionMark = false;
        }
        else
        {
            cell.SetImage(Img.Flag);
            --Game.flagsLeft;  // decrement flag counter
            cell.isFlag = true;

        }
    }
    
    public abstract void LeftClick();

}