using UnityEngine;

public class LoadProgressState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IYandexService _yandexService;

    public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService, IYandexService yandexService)
    {
        _gameStateMachine = gameStateMachine;
        _progressService = progressService;
        _saveLoadService = saveLoadService;
        _yandexService = yandexService;
    }

    public void Enter()
    {
        Debug.Log("LoadProgressState");
        // TEST
        LoadProgressOrInitNew();
        _gameStateMachine.Enter<LoadMainMenuState, string>(Constants.MAIN_MENU_SCENE_NAME);

//#if PLATFORM_WEBGL
//        _yandexService.API.OnYandexProgressCopied += LoadPlayerProgress;
//        _yandexService.API.LoadFromYandex();
//#endif
    }

    public void Exit()
    {
//#if PLATFORM_WEBGL
//        _yandexService.API.OnYandexProgressCopied -= LoadPlayerProgress;
//#endif
    }

    private void LoadProgressOrInitNew() =>
        _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

    private PlayerProgress NewProgress()
    {
        Debug.Log("Progress is null. Create new progress");
        return new(initialLevel: Constants.NEW_PROGRESS_FIRST_LEVEL_SCENE_NAME);
    }

    private void LoadPlayerProgress()
    {
        LoadProgressOrInitNew();
        //_gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.PositionOnLevel.Level);
        _gameStateMachine.Enter<LoadMainMenuState, string>(Constants.MAIN_MENU_SCENE_NAME);
    }
}
