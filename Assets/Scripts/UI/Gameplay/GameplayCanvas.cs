using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameMetaData;

public class GameplayCanvas : MonoBehaviour, ISavedProgress
{
    [SerializeField] private LevelCompletePopup _LevelCompletePopup;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private CurrentLevelDisplay _levelDisplay;

    private ILevelCellsService _levelCellsService;

    public static Action OnNextLevel;
    public static Action OnRestartLevel;
    public static Action OnMainMenuButton;

    private string _nextLevelName;

    private void OnEnable()
    {
        _levelCellsService = AllServices.Container.Single<ILevelCellsService>();
        _levelCellsService.SetCurrentCell();

        _LevelCompletePopup.gameObject.SetActive(false);

        LevelState.OnLevelResultShow += ShowLevelCompletePopup;
        GameLoopState.OnNextLevelNameSet += UpdateNextLevel;

        UpdateLevelDisplay();
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveAllListeners();
        LevelState.OnLevelResultShow -= ShowLevelCompletePopup;
    }

    private void ShowLevelCompletePopup(bool showArtifact)
    {
        _levelCellsService.SaveCompletedLevel(showArtifact);
        _levelCellsService.UnlockNextLevel(_nextLevelName);

        _LevelCompletePopup.ShowArtifact(showArtifact);
        _LevelCompletePopup.gameObject.SetActive(true);
    }

    // Send callback for GameLoopState
    public void LoadMainMenu() => 
        OnMainMenuButton?.Invoke();

    private void UpdateLevelDisplay() =>
        _levelDisplay.SetLevelNumber(_levelCellsService.Current.LevelNumber);

    private void UpdateNextLevel(string name) => 
        _nextLevelName = name;

    public void UpdateProgress(PlayerProgress progress)
    {
        progress.gameData.nextLevel = _nextLevelName;
        CopyProgress(_levelCellsService.Levels, progress.gameData.levels);
    }

    public void LoadProgress(PlayerProgress progress) => 
        _nextLevelName = progress.gameData.nextLevel;


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
