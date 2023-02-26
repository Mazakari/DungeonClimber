using System;
using UnityEngine;

public class GameLoopState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly SceneLoader _sceneLoader;

    private string _currentLevelName;
    private string _nextLevelName;

    public static event Action<string> OnNextLevelNameSet;

    public GameLoopState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, SceneLoader sceneLoader)
    {
        _gameStateMachine = gameStateMachine;
        _progressService = progressService;
        _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
        Debug.Log("GameLoopState");

        SetLevelNames();

        //GameplayCanvas.OnMainMenuButton += LoadMainMenu;
        //GameplayLevelComplete_Popup.OnNextLevel += LoadNextLevel;
        //GameplayLevelComplete_Popup.OnRestartLevel += RestartLevel;
        //DeadZone.OnDeadZoneEnter += RestartLevel;
    }
    public void Exit()
    {
        //GameplayCanvas.OnMainMenuButton -= LoadMainMenu;
        //GameplayLevelComplete_Popup.OnNextLevel -= LoadNextLevel;
        //GameplayLevelComplete_Popup.OnRestartLevel -= RestartLevel;
        //DeadZone.OnDeadZoneEnter -= RestartLevel;
    }

    private void SetLevelNames()
    {
        _currentLevelName = _sceneLoader.GetCurrentLevelName();
        _nextLevelName = _sceneLoader.GetNextLevelName();

        // Send callback to GameplayCanvas with next level name
        OnNextLevelNameSet?.Invoke(_nextLevelName);

        Debug.Log($"_currentLevelName = {_currentLevelName}");
        Debug.Log($"_nextLevelName = {_nextLevelName}");
    }

    private void LoadMainMenu() =>
        _gameStateMachine.Enter<LoadMainMenuState, string>(Constants.MAIN_MENU_SCENE_NAME);

    private void RestartLevel() =>
        _gameStateMachine.Enter<LoadLevelState, string>(_currentLevelName);

    private void LoadNextLevel() =>
        _gameStateMachine.Enter<LoadLevelState, string>(_nextLevelName);
}
