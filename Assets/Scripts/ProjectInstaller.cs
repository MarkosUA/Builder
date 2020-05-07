using Zenject;
using UnityEngine;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField]
    private LevelSettings _levelSettings;
    [SerializeField]
    private DataBuilderPrefab _dataBuilderPrefab;
    [SerializeField]
    private DataBuildingsSettings _dataBuildingsSettings;
    
    public override void InstallBindings()
    {
        Container.Bind<LevelSettings>().FromInstance(_levelSettings).AsSingle();
        Container.Bind<DataBuilderPrefab>().FromInstance(_dataBuilderPrefab).AsSingle();
        Container.Bind<DataBuildingsSettings>().FromInstance(_dataBuildingsSettings).AsSingle();
    }
}
