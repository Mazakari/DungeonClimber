using System;
using UnityEngine;

public class GameLoopState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private ISaveLoadService _saveLoadService;
    private readonly ILevelCellsService _levelCells;

    private string _currentLevelName;
    private string _nextLevelName;

    public static event Action<string> OnNextLevelNameSet;

    public GameLoopState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, ISaveLoadService saveLoadService, ILevelCellsService levelCells)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _saveLoadService = saveLoadService;
        _levelCells = levelCells;
    }

    public void Enter()
    {
        Debug.Log("GameLoopState");

        SetLevelNames();

        GameplayCanvas.OnMainMenuButton += LoadMainMenu;
        GameplayCanvas.OnNextLevel += LoadNextLevel;

        GameplayCanvas.OnRestartLevel += RestartLevel;
        DeathTrigger.OnDeadZoneEnter += RestartLevel;
        EnemyCollision.OnEnemyCollision += RestartLevel;
    }
    public void Exit()
    {
        GameplayCanvas.OnMainMenuButton -= LoadMainMenu;
        GameplayCanvas.OnNextLevel -= LoadNextLevel;

        GameplayCanvas.OnRestartLevel -= RestartLevel;
        DeathTrigger.OnDeadZoneEnter -= RestartLevel;
        EnemyCollision.OnEnemyCollision -= RestartLevel;
    }

    private void SetLevelNames()
    {
        _currentLevelName = _sceneLoader.GetCurrentLevelName();
        _nextLevelName = _sceneLoader.GetNextLevelName();

        OnNextLevelNameSet?.Invoke(_nextLevelName);
    }

    private void LoadMainMenu() =>
        _gameStateMachine.Enter<LoadMainMenuState, string>(Constants.MAIN_MENU_SCENE_NAME);

    private void RestartLevel() =>
        _gameStateMachine.Enter<LoadLevelState, string>(_currentLevelName);

    private void LoadNextLevel()
    {
        _saveLoadService.SaveProgress();
        _gameStateMachine.Enter<LoadLevelState, string>(_nextLevelName);
    }
}
