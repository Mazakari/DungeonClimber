using UnityEngine;

public class LevelsService
{
	private LevelCell[] _levels;
    public LevelCell[] Levels => _levels;

	private int _levelsCount;

    private LevelsDataSO _levelsDataSO;
    private GameFactoryService _gameFactory;

    public LevelsService(GameFactoryService gameFactory)
	{
        _gameFactory = gameFactory;

        InitService();
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
            _levels[i] = _gameFactory.CreateLevel();
        }
    }

    private void InitService()
    {
        _levelsDataSO = Resources.Load<LevelsDataSO>(Constants.LEVELS_DATA_SO_PATH);
        //_levelsCount = Services.SceneLoaderService.GetLevelsCount();
       
        _levels = new LevelCell[_levelsCount];
        CreateLevels();

        InitLevels();
    }

}
