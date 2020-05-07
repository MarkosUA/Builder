using Zenject;

public class Tree : Building
{
    [Inject]
    private void Construct(DataBuildingsSettings dataBuildingsSettings)
    {
        numberOfOccupiedCellsX = dataBuildingsSettings.TreeNumberOfOccupiedCellsX;
        numberOfOccupiedCellsZ = dataBuildingsSettings.TreeNumberOfOccupiedCellsZ;
    }

    public class Factory : PlaceholderFactory<Tree>
    {

    }
}
