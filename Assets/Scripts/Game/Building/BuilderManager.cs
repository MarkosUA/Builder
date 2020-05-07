using UnityEngine;

public class BuilderManager : IBuilderManager
{
    private DataBuilderPrefab _dataBuilderPrefab;
    private Border _border;
    private PlayerBuildings _playerBuildings;

    private ICheckBeforeBuild _checkBeforeBuild;
    private IBuilder _builder;

    public BuilderManager(DataBuilderPrefab dataBuilderPrefab, Border border, PlayerBuildings playerBuildings,
        ICheckBeforeBuild checkBeforeBuild, IBuilder builder)
    {
        _dataBuilderPrefab = dataBuilderPrefab;
        _checkBeforeBuild = checkBeforeBuild;
        _builder = builder;
        _border = border;
        _playerBuildings = playerBuildings;
    }

    public bool Build(int iIndex, int jIndex, Cell[,] cells)
    {
        return CallCheckAndBuild(iIndex, jIndex, cells, cells[iIndex, jIndex].Building.GetComponent<Building>(),
            _playerBuildings.gameObject);
    }

    public void RandomBorderBuild(Cell[,] borderCells)
    {
        for (int i = 0; i < borderCells.GetLength(0); i++)
        {
            for (int j = 0; j < borderCells.GetLength(1); j++)
            {
                if (borderCells[i, j] != null)
                {
                    ChooseRandBuildings(i, j, borderCells);
                }
            }
        }
    }

    private void ChooseRandBuildings(int iIndex, int jIndex, Cell[,] cells)
    {
        var rand = Random.Range(0, 6);

        switch (rand)
        {
            case 0:
                cells[iIndex, jIndex].Building = _dataBuilderPrefab.Stone.gameObject;
                CallCheckAndBuild(iIndex, jIndex, cells, _dataBuilderPrefab.Stone, _border.gameObject);
                break;

            case 2:
                cells[iIndex, jIndex].Building = _dataBuilderPrefab.Tree.gameObject;
                CallCheckAndBuild(iIndex, jIndex, cells, _dataBuilderPrefab.Tree, _border.gameObject);
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;
        }
    }

    private bool CallCheckAndBuild(int iIndex, int jIndex, Cell[,] cells, Building buildings, GameObject parent)
    {
        if (_checkBeforeBuild.CheckCell(iIndex, jIndex, cells))
        {
            var newBuilding = _builder.BuildBuilding(cells[iIndex, jIndex]);
            newBuilding.transform.SetParent(parent.transform);

            var XIndex = iIndex;
            var ZIndex = jIndex;

            for (int i = 0; i < newBuilding.GetComponent<Building>().NumberOfOccupiedCellsX; i++)
            {
                for (int j = 0; j < newBuilding.GetComponent<Building>().NumberOfOccupiedCellsZ; j++)
                {
                    if (XIndex < cells.GetLength(0) && ZIndex < cells.GetLength(1))
                    {
                        cells[XIndex, ZIndex].Occupied = true;
                        cells[XIndex, ZIndex].gameObject.SetActive(false);
                        XIndex++;
                    }
                }
                ZIndex++;
                XIndex = iIndex;
            }
        }
        else
        {
            cells[iIndex, jIndex].Building = null;
            return false;
        }
        return true; ;
    }
}
