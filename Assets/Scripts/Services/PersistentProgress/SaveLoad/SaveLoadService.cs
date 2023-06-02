using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private readonly IPersistentProgressService _progressService;
    private readonly IGameFactory _gameFactory;
    private readonly IYandexService _yandexService;

    public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory, IYandexService yandexService)
    {
        _progressService = progressService;
        _gameFactory = gameFactory;
        _yandexService = yandexService;
    }

    public void SaveProgress()
    {
        foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
        {
            progressWriter.UpdateProgress(_progressService.Progress);
        }

        string progress = _progressService.Progress.ToJson();

#if !UNITY_EDITOR
        Debug.Log("SaveLoadService.SaveProgress save to Yandex");
        SaveProgressToYandex(progress);
#endif

        PlayerPrefs.SetString(Constants.PROGRESS_KEY, progress);
    }

    public PlayerProgress LoadProgress()
    {
        string progressString;
        PlayerProgress playerProgress = null;

        progressString = PlayerPrefs.GetString(Constants.PROGRESS_KEY);

#if !UNITY_EDITOR
        Debug.Log("SaveLoadService.LoadProgress from Yandex");
        progressString = _yandexService.API.PlayerProgress;
#endif

        if (progressString != null)
        {
            playerProgress = progressString.ToDeserialized<PlayerProgress>();
        }

        return playerProgress;
    }

    private void SaveProgressToYandex(string progress) => 
        _yandexService.API.SaveToYandex(progress);
}
