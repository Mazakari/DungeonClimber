using UnityEngine;

public class MainMenuState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    public MainMenuState(GameStateMachine gameStateMachine) => 
        _gameStateMachine = gameStateMachine;

    public void Enter()
    {
        Debug.Log("MainMenuState");
        LevelCell.OnLevelCellPress += StartGame;
    }

    private void StartGame(string levelName) =>
        _gameStateMachine.Enter<LoadLevelState, string>(levelName);

    public void Exit() => 
        LevelCell.OnLevelCellPress -= StartGame;
}
