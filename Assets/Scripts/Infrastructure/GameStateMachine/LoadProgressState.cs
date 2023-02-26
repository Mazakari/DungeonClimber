using UnityEngine;

public class LoadProgressState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;

    public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
    {
        _gameStateMachine = gameStateMachine;
        _progressService = progressService;
        _saveLoadService = saveLoadService;
    }

    public void Enter()
    {
        Debug.Log("LoadProgressState");
        LoadProgressOrInitNew();
        //_gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.PositionOnLevel.Level);
        _gameStateMachine.Enter<LoadMainMenuState, string>(Constants.MAIN_MENU_SCENE_NAME);
    }

    public void Exit()
    {
    }

    private void LoadProgressOrInitNew() =>
        _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

    private PlayerProgress NewProgress() => new(
        initialLevel: Constants.NEW_PROGRESS_FIRST_LEVEL_SCENE_NAME);
}
