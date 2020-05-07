using UnityEngine;

public class Builder : IBuilder
{
    private DataBuilderPrefab _dataBuilderPrefab;
    private Stone.Factory _stoneFactory;
    private Tree.Factory _treeFactory;

    private int _buildingId;

    public Builder(DataBuilderPrefab dataBuilderPrefab, Stone.Factory stoneFactory, Tree.Factory treeFactory)
    {
        _dataBuilderPrefab = dataBuilderPrefab;
        _stoneFactory = stoneFactory;
        _treeFactory = treeFactory;
        _buildingId = 0;
    }

    public GameObject BuildBuilding(Cell cell)
    {
        GameObject newBuilding;

        if (cell.Building == _dataBuilderPrefab.Stone.gameObject)
        {
            newBuilding = _stoneFactory.Create().gameObject;
        }
        else
        {
            newBuilding = _treeFactory.Create().gameObject;
        }

        float positionX;
        float positionZ;

        if (newBuilding.GetComponent<Building>().NumberOfOccupiedCellsX % 2 == 0)
        {
            positionX = cell.transform.position.x - (newBuilding.GetComponent<Building>().NumberOfOccupiedCellsX - 0.75f) / 2;
        }
        else
        {
            positionX = cell.transform.position.x - (newBuilding.GetComponent<Building>().NumberOfOccupiedCellsX - 1) / 2;
        }

        if (newBuilding.GetComponent<Building>().NumberOfOccupiedCellsZ % 2 == 0)
        {
            positionZ = cell.transform.position.z - (newBuilding.GetComponent<Building>().NumberOfOccupiedCellsZ - 0.75f) / 2;
        }
        else
        {
            positionZ = cell.transform.position.z - (newBuilding.GetComponent<Building>().NumberOfOccupiedCellsZ - 1) / 2;
        }

        var position = new Vector3(positionX, cell.transform.position.y + cell.Building.GetComponent<MeshRenderer>().bounds.size.y / 2,
          positionZ);

        newBuilding.GetComponent<Building>().SessionID = _buildingId++;

        newBuilding.transform.position = position;

        return newBuilding;
    }

}
