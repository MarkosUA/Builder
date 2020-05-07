
public class CheckBeforeBuild : ICheckBeforeBuild
{
    private DataBuilderPrefab _dataBuilderPrefab;
    private DataBuildingsSettings _dataBuildingsSettings;

    public CheckBeforeBuild(DataBuilderPrefab dataBuilderPrefab, DataBuildingsSettings dataBuildingsSettings)
    {
        _dataBuilderPrefab = dataBuilderPrefab;
        _dataBuildingsSettings = dataBuildingsSettings;
    }

    public bool CheckCell(int iIndex, int jIndex, Cell[,] cells)
    {
        int countOfTheConstructionCellsX;
        int countOfTheConstructionCellsZ;

        if (cells[iIndex, jIndex].Building == _dataBuilderPrefab.Stone.gameObject)
        {
            countOfTheConstructionCellsX = _dataBuildingsSettings.StoneNumberOfOccupiedCellsX;
            countOfTheConstructionCellsZ = _dataBuildingsSettings.StoneNumberOfOccupiedCellsZ;
        }
        else
        {
            countOfTheConstructionCellsX = _dataBuildingsSettings.TreeNumberOfOccupiedCellsX;
            countOfTheConstructionCellsZ = _dataBuildingsSettings.TreeNumberOfOccupiedCellsZ;
        }

        var Xindex = iIndex;
        var Zindex = jIndex;

        for (int i = 0; i < countOfTheConstructionCellsX; i++)
        {
            for (int j = 0; j < countOfTheConstructionCellsZ; j++)
            {
                if (Xindex < 0 || Xindex >= cells.GetLength(0) || Zindex < 0 || Zindex >= cells.GetLength(0))
                {
                    return false;
                }
                if (cells[Xindex, Zindex] == null || cells[Xindex, Zindex].Occupied)
                {
                    return false;
                }
                Zindex++;
            }
            Xindex++;
            Zindex = jIndex;
        }
        return true;
    }

}
