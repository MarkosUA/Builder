
public interface IBuilderManager
{
    bool Build(int iIndex, int jIndex, Cell[,] cells);
    void RandomBorderBuild(Cell[,] borderCells);
}
