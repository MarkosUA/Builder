using UnityEngine;
using Zenject;

public class BuildingSelector : MonoBehaviour
{
    private PlayerController _playerController;
    private DataBuilderPrefab _dataBuilderPrefab;

    [Inject]
    private void Construct(PlayerController playerController, DataBuilderPrefab dataBuilderPrefab)
    {
        _playerController = playerController;
        _dataBuilderPrefab = dataBuilderPrefab;
    }

    public void SelectStone()
    {
        _playerController.StartPlayerBuilding(_dataBuilderPrefab.Stone);
    }

    public void SelectTree()
    {
        _playerController.StartPlayerBuilding(_dataBuilderPrefab.Tree);
    }
}
