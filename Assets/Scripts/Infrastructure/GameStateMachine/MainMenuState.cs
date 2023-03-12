using UnityEngine;

public class MainMenuState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly ISaveLoadService _saveLoadService;

    public MainMenuState(GameStateMachine gameStateMachine, ISaveLoadService progressService)
    {
        _gameStateMachine = gameStateMachine;
        _saveLoadService = progressService;
    }

    public void Enter()
    {
        Debug.Log("MainMenuState");
        LevelCell.OnLevelCellPress += StartGame;
    }

    private void StartGame(string levelName) =>
        _gameStateMachine.Enter<LoadLevelState, string>(levelName);

    public void Exit()
    {
        _saveLoadService.SaveProgress();
        LevelCell.OnLevelCellPress -= StartGame;
    }
}
