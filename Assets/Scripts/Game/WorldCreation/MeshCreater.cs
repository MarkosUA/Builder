using UnityEngine;

public class MeshCreater : IMeshCreater
{
    private Cell.Factory _cellFactory;

    private float _gameZoneSizeX;
    private float _gameZoneSizeZ;
    private float _cellSize;

    public MeshCreater(Cell.Factory cellFactory)
    {
        _cellFactory = cellFactory;
        var newcell = _cellFactory.Create();
        _cellSize = newcell.GetComponent<SpriteRenderer>().bounds.size.x;
        newcell.DeleteObj();
    }

    public Cell[,] CreateMesh(GameZone gameZone)
    {
        SizeCalculation(gameZone);

        return BuildCells(gameZone);
    }

    private void SizeCalculation(GameZone gameZone)
    {
        _gameZoneSizeX = gameZone.GetComponent<MeshRenderer>().bounds.size.x;
        _gameZoneSizeZ = gameZone.GetComponent<MeshRenderer>().bounds.size.z;
    }

    private int CellCount(float zoneSize)
    {
        return Mathf.FloorToInt(zoneSize / _cellSize);
    }

    private Cell[,] BuildCells(GameZone gameZone)
    {
        var XCount = CellCount(_gameZoneSizeX);
        var ZCount = CellCount(_gameZoneSizeZ);

        var cells = new Cell[XCount, ZCount];

        var createPosition = new Vector3(_gameZoneSizeX / 2 - _cellSize / 2,
            gameZone.transform.position.y + 0.01f, _gameZoneSizeZ / 2 - _cellSize / 2);

        for (int i = 0; i < XCount; i++)
        {
            for (int j = 0; j < ZCount; j++)
            {
                var newCell = _cellFactory.Create();
                newCell.transform.position = createPosition;
                createPosition.z -= _cellSize;
                cells[i,j] = newCell;
                newCell.transform.SetParent(gameZone.transform);
            }
            createPosition.x -= _cellSize;
            createPosition.z = _gameZoneSizeZ / 2 - _cellSize / 2;
        }
        return cells;
    }
}
