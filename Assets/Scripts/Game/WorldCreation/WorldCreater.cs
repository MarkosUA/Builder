using UnityEngine;

public class WorldCreater : IWorldCreater
{
    private GameZone.Factory _gameZoneFactory;

    private IMeshCreater _meshCreater;
    private IWorldPlaceholder _worldPlaceholder;

    public WorldCreater(IMeshCreater meshCreater, IWorldPlaceholder worldPlaceholder, GameZone.Factory gameZoneFactory)
    {
        _meshCreater = meshCreater;
        _gameZoneFactory = gameZoneFactory;
        _worldPlaceholder = worldPlaceholder;
    }

    public void CreateWorld()
    {
        var meshes = _meshCreater.CreateMesh(CreateGameZone());
        _worldPlaceholder.FillTheWorld(meshes);
    }

    private GameZone CreateGameZone()
    {
        var gameZone = _gameZoneFactory.Create();
        gameZone.transform.position = Vector3.zero;
        return gameZone;
    }
}
