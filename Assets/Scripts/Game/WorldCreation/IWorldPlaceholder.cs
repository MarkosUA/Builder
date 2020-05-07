
public interface IWorldPlaceholder
{
    Cell[,] PlayableCells { get; }
    void FillTheWorld(Cell[,] cells);
    bool SearchCell(Cell cell);
}
