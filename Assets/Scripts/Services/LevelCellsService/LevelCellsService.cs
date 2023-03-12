using UnityEngine;

public class LevelCellsService : ILevelCellsService
{
    private LevelCell[] _levels;
    public LevelCell[] Levels => _levels;

    public LevelCell Current { get; private set; }

    private int _levelsCount;

    private LevelsDataSO _levelsDataSO;

    private readonly IGameFactory _gameFactory;
    private readonly SceneLoader _sceneLoader;

    public LevelCellsService(IGameFactory gameFactory, SceneLoader sceneLoader)
    {
        _gameFactory = gameFactory;
        _sceneLoader = sceneLoader;
    }

    public void InitService()
    {
        _levelsDataSO = Resources.Load<LevelsDataSO>(Constants.LEVELS_DATA_SO_PATH);
        _levelsCount = _sceneLoader.GetLevelsCount();

        _levels = new LevelCell[_levelsCount];
        CreateLevels();

        InitLevels();
    }

    public void SaveCompletedLevel(bool artifactLocked) => 
        Current.SaveCompletedLevel(artifactLocked);

    public void SetCurrentCell()
    {
        string name = _sceneLoader.GetCurrentLevelName();
        Current = GetCellByName(name);
    }

    public void UnlockNextLevel(string nextLevelName)
    {
        LevelCell nextLevel = GetCellByName(nextLevelName);
        nextLevel.UnlockLevel();

    }

    private LevelCell GetCellByName(string name)
    {
        LevelCell cell = _levels[0];

        for (int i = 0; i < _levels.Length; i++)
        {
            if (_levels[i].LevelSceneName.Equals(name))
            {
                cell = _levels[i];
            }
        }

        return cell;
    }

    private void InitLevels()
    {
        string name;
        int number;
        bool levelLocked;

        Sprite artifactSprite;
        bool artifactLocked;

        for (int i = 0; i < _levelsDataSO.LevelsData.Length; i++)
        {
            name = _levelsDataSO.LevelsData[i].LevelSceneName;
            number = i + 1;
            levelLocked = _levelsDataSO.LevelsData[i].LevelLocked;

            artifactSprite = _levelsDataSO.LevelsData[i].LevelArtifactSprite;
            artifactLocked = _levelsDataSO.LevelsData[i].ArtifactLocked;

            _levels[i].InitLevelCell(number, name, levelLocked, artifactSprite, artifactLocked);
        }
    }

    private void CreateLevels()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i] = _gameFactory.CreateLevelCell().GetComponent<LevelCell>();
        }
    }

    
}
