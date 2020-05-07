using Zenject;
using UnityEngine;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField]
    private GameZone _gameZone;
    [SerializeField]
    private Cell _cell;
    [SerializeField]
    private Stone _stone;
    [SerializeField]
    private Tree _tree;
    [SerializeField]
    private ShowMeshBtn _showMeshBtn;
    [SerializeField]
    private OpenShopPanel _openMenuBtn;
    [SerializeField]
    private CloseShopPanel _closeShopPanel;
    [SerializeField]
    private ShopPanel _shopPanel;
    [SerializeField]
    private Border _border;
    [SerializeField]
    private PlayerBuildings _playerBuildings;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private PlayerController _playerController;

    public override void InstallBindings()
    {
        BindAllInterfaces();
        BindAllObjsScripts();
        BindAllFactories();
    }

    private void BindAllInterfaces()
    {
        Container.Bind<IMeshCreater>().To<MeshCreater>().AsSingle();
        Container.Bind<IGameController>().To<GameController>().AsSingle();
        Container.Bind<IWorldCreater>().To<WorldCreater>().AsSingle();
        Container.Bind<IBuilderManager>().To<BuilderManager>().AsSingle();
        Container.Bind<IWorldPlaceholder>().To<WorldPlaceholder>().AsSingle();
        Container.Bind<ICheckBeforeBuild>().To<CheckBeforeBuild>().AsSingle();
        Container.Bind<IBuilder>().To<Builder>().AsSingle();
        Container.Bind<IMenuController>().To<MenuController>().AsSingle();
        Container.Bind<IMeshManager>().To<MeshManager>().AsSingle();
    }

    private void BindAllObjsScripts()
    {
        Container.Bind<ShowMeshBtn>().FromInstance(_showMeshBtn).AsSingle();
        Container.Bind<OpenShopPanel>().FromInstance(_openMenuBtn).AsSingle();
        Container.Bind<CloseShopPanel>().FromInstance(_closeShopPanel).AsSingle();
        Container.Bind<ShopPanel>().FromInstance(_shopPanel).AsSingle();
        Container.Bind<Border>().FromInstance(_border).AsSingle();
        Container.Bind<PlayerBuildings>().FromInstance(_playerBuildings).AsSingle();
        Container.Bind<Camera>().FromInstance(_camera).AsSingle();
        Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle();
        Container.Bind<GameZone>().FromInstance(_gameZone).AsSingle();
    }

    private void BindAllFactories()
    {
        Container.BindFactory<Cell, Cell.Factory>().FromComponentInNewPrefab(_cell).AsSingle();
        Container.BindFactory<GameZone, GameZone.Factory>().FromComponentInNewPrefab(_gameZone).AsSingle();
        Container.BindFactory<Stone, Stone.Factory>().FromComponentInNewPrefab(_stone).AsSingle();
        Container.BindFactory<Tree, Tree.Factory>().FromComponentInNewPrefab(_tree).AsSingle();
    }
}
