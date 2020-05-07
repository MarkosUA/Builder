
public class GameController : IGameController
{
    private IWorldCreater _worldCreater;

    public GameController(IWorldCreater worldCreater)
    {
        _worldCreater = worldCreater;
    }

    public void StartGame()
    {
        _worldCreater.CreateWorld();
    }
}
