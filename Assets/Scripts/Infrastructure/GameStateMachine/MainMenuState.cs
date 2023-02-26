using UnityEngine;

public class MainMenuState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _progressService;

    public MainMenuState(GameStateMachine gameStateMachine, IPersistentProgressService progressService)
    {
        _gameStateMachine = gameStateMachine;
        _progressService = progressService;
    }

    public void Enter()
    {
        Debug.Log("MainMenuState");
        //MainMenuCanvas.OnStartButtonPress += StartGame;
    }

    private void StartGame() =>
        _gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.gameData.nextLevel);

    //private void LoadShop() =>
    //    _gameStateMachine.Enter<LoadShopState, string>(Constants.SHOP_SCENE_NAME);

    public void Exit()
    {
        //MainMenuCanvas.OnStartButtonPress -= StartGame;
    }
}
