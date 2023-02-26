using UnityEngine;
using UnityEngine.UI;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] private LevelCompletePopup _LevelCompletePopup;
    [SerializeField] private Button _mainMenuButton;

    private SystemSettingsService _systemSettingsService;

    private void OnEnable()
    {
        //_systemSettingsService = Services.SystemSettingsService;
        _systemSettingsService.HideMouseCursor();

        _LevelCompletePopup.gameObject.SetActive(false);

        //_mainMenuButton.onClick.AddListener(LoadMainMenu);

        LevelState.OnLevelResultShow += ShowLevelCompletePopup;
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveAllListeners();
        LevelState.OnLevelResultShow -= ShowLevelCompletePopup;
    }

    //private void LoadMainMenu() => 
    //    Services.SceneLoaderService.LoadMainMenu();
    private void ShowLevelCompletePopup(bool showArtifact)
    {
        _LevelCompletePopup.gameObject.SetActive(true);
        _systemSettingsService.ShowMouseCursor();

        //_LevelCompletePopup.ShowPopup(showArtifact);
    }
}
