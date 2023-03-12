using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameMetaData;

public class MainMenuCanvas : MonoBehaviour, ISavedProgress
{
    [Header("Buttons")]
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _selectLevelsButton;
    [SerializeField] private Button _quitGameButton;

    [Header("Level Selection Popup")]
    [Space(10)]
    [SerializeField] private GameObject _levelSelectionPopup;
    [SerializeField] private Transform _levelSelectionContent;

    private ILevelCellsService _levelCellsService;


    private void OnEnable()
    {
        _levelCellsService = AllServices.Container.Single<ILevelCellsService>();

        _levelSelectionPopup.SetActive(false);
        _quitGameButton.onClick.AddListener(QuitGame);
    }

    private void Start()
    {
        //_levelCellsService = AllServices.Container.Single<ILevelCellsService>();
        InitLevelsSelectionPopup();
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveAllListeners();
        _quitGameButton.onClick.RemoveAllListeners();
    }

    public void ShowSelectLevelsPopup() => 
        _levelSelectionPopup.SetActive(true);

    public void HideSelectLevelsPopup() => 
        _levelSelectionPopup.SetActive(false);

    private void QuitGame() => 
        Application.Quit();

    private void InitLevelsSelectionPopup()
    {
        for (int i = 0; i < _levelCellsService.Levels.Length; i++)
        {
            _levelCellsService.Levels[i].transform.SetParent(_levelSelectionContent);
        }
    }

    public void UpdateProgress(PlayerProgress progress) => 
        CopyProgress(_levelCellsService.Levels, progress.gameData.levels);

    public void LoadProgress(PlayerProgress progress)
    {
        int number;
        string name;
        bool locked;

        Sprite sprite;
        bool artifactLocked;

        if (progress.gameData.levels.Count > 0)
        {
            for (int i = 0; i < progress.gameData.levels.Count; i++)
            {
                number = progress.gameData.levels[i].number;
                name = progress.gameData.levels[i].sceneName;
                locked = progress.gameData.levels[i].locked;

                sprite = progress.gameData.levels[i].artifactSprite;
                artifactLocked = progress.gameData.levels[i].artifactLocked;
                

                _levelCellsService.Levels[i].InitLevelCell(number, name, locked, sprite, artifactLocked);
            }
        }
    }

    private void CopyProgress(LevelCell[] source, List<LevelCellsData> target)
    {
        target.Clear();

        for (int i = 0; i < source.Length; i++)
        {
            LevelCellsData data;
            data.number = source[i].LevelNumber;
            data.locked = source[i].LevelLocked;
            data.sceneName = source[i].LevelSceneName;

            data.artifactSprite = source[i].ArtifactSprite;
            data.artifactLocked = source[i].ArtifactLocked;

            target.Add(data);
        }
    }
}
