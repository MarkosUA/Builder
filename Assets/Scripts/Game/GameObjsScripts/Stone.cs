using Zenject;

public class Stone : Building
{
    [Inject]
    private void Construct(DataBuildingsSettings dataBuildingsSettings)
    {
        numberOfOccupiedCellsX = dataBuildingsSettings.StoneNumberOfOccupiedCellsX;
        numberOfOccupiedCellsZ = dataBuildingsSettings.StoneNumberOfOccupiedCellsZ;
    }

    public class Factory : PlaceholderFactory<Stone>
    {

    }
}
