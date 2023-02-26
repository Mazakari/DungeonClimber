using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private readonly IPersistentProgressService _progressService;
    private readonly IGameFactory _gameFactory;

    public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
    {
        _progressService = progressService;
        _gameFactory = gameFactory;
    }

    public void SaveProgress()
    {
        foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
        {
            progressWriter.UpdateProgress(_progressService.Progress);
        }

        PlayerPrefs.SetString(Constants.PROGRESS_KEY, _progressService.Progress.ToJson());
    }

    public PlayerProgress LoadProgress() => 
        PlayerPrefs.GetString(Constants.PROGRESS_KEY)?.ToDeserialized<PlayerProgress>();

}
