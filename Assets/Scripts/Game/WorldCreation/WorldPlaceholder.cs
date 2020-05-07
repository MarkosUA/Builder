
public class WorldPlaceholder : IWorldPlaceholder
{
    private LevelSettings _levelSettings;

    private IBuilderManager _builderManager;

    private Cell[,] _borderCells;
    private Cell[,] _playableCells;

    public Cell[,] PlayableCells
    {
        get { return _playableCells; }
    }

    public WorldPlaceholder(LevelSettings levelSettings, IBuilderManager builderManager)
    {
        _levelSettings = levelSettings;
        _builderManager = builderManager;
    }

    public void FillTheWorld(Cell[,] cells)
    {
        FillTheArrays(cells);
        _builderManager.RandomBorderBuild(_borderCells);
        DisableBorders();
    }

    public bool SearchCell(Cell cell)
    {
        for (int i = 0; i < _playableCells.GetLength(0); i++)
        {
            for (int j = 0; j < _playableCells.GetLength(1); j++)
            {
                if (PlayableCells[i,j] == cell)
                {
                    return _builderManager.Build(i, j, _playableCells);                    
                }
            }
        }
        return false;
    }

    private void FillTheArrays(Cell[,] cells)
    {
        _borderCells = new Cell[cells.GetLength(0), cells.GetLength(1)];
        _playableCells = new Cell[cells.GetLength(0) - _levelSettings.WidthBorder * 2,
            cells.GetLength(1) - _levelSettings.WidthBorder * 2];

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if (i >= _levelSettings.WidthBorder && i < (cells.GetLength(0) - _levelSettings.WidthBorder))
                {
                    if (j >= _levelSettings.WidthBorder && j < (cells.GetLength(1) - _levelSettings.WidthBorder))
                    {
                        _playableCells[i - _levelSettings.WidthBorder, j - _levelSettings.WidthBorder] = cells[i, j];
                    }
                    else
                    {
                        _borderCells[i, j] = cells[i, j];
                    }
                }
                else
                {
                    _borderCells[i, j] = cells[i, j];
                }
            }
        }
    }

    private void DisableBorders()
    {
        for (int i = 0; i < _borderCells.GetLength(0); i++)
        {
            for (int j = 0; j < _borderCells.GetLength(1); j++)
            {
                if (_borderCells[i, j] != null)
                    _borderCells[i, j].DeleteObj();
            }
        }
    }

}
