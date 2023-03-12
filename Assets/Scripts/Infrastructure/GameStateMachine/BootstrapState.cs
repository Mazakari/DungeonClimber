using UnityEngine;

public class BootstrapState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;
    //private readonly VolumeControl _volumeControl;

    public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _services = services;
        //_volumeControl = volumeControl;

        RegisterServices();
    }

    public void Enter()
    {
        Cursor.lockState = CursorLockMode.Confined;

        // TO DO Unity bug with GetSceneByBuildIndex() Init scene names manualy
        _sceneLoader.GetBuildNamesFromBuildSettings();

        Debug.Log("BootstrapState");
        _sceneLoader.Load(Constants.INITIAL_SCENE_NAME, onLoaded: EnterLoadLevel);
    }

    private void EnterLoadLevel() =>
        _gameStateMachine.Enter<LoadProgressState>();

    public void Exit()
    {

    }

    private void RegisterServices()
    {
        //_services.RegisterSingle<IInputService>(new InputService());
        _services.RegisterSingle<IAssets>(new AssetProvider());
        _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
        _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
        _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(), _services.Single<IGameFactory>()));
        _services.RegisterSingle<ITimeService>(new TimeService());
        _services.RegisterSingle<ILevelCellsService>(new LevelCellsService(_services.Single<IGameFactory>(), _sceneLoader));
        //_services.RegisterSingle<IAudioService>(new AudioService(_volumeControl));
    }
}
