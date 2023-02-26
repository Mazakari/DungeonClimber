using UnityEngine;

public class LoadMainMenuState : IPayloadedState<string>
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactory _gameFactory;
    private readonly LoadingCurtain _curtain;
    private IPersistentProgressService _progressService;

    public LoadMainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory, IPersistentProgressService progressService)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _gameFactory = gameFactory;
        _curtain = curtain;
        _gameFactory = gameFactory;
        _progressService = progressService;
    }

    public void Enter(string sceneName)
    {
        Debug.Log("LoadMainMenuState");
        _curtain.Show();
        _gameFactory.Cleanup();
        _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit() =>
        _curtain?.Hide();

    private void OnLoaded()
    {
        InitMainMenu();
        InitVolumeControl();

        InformProgressReaders();
        _gameStateMachine.Enter<MainMenuState>();
    }

    private void InitMainMenu() =>
        _gameFactory.CreateMainMenulHud();

    private void InitVolumeControl()
    {
        VolumeControl vc = GameObject.FindObjectOfType<VolumeControl>();
        if (vc != null) return;

        _gameFactory.CreateVolumeControl();
    }

    private void InformProgressReaders()
    {
        foreach (ISavedProgress progressReader in _gameFactory.ProgressReaders)
        {
            progressReader.LoadProgress(_progressService.Progress);
        }
    }
}
