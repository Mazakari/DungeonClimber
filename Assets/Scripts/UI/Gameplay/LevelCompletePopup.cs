using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletePopup : MonoBehaviour
{
    [SerializeField] private TMP_Text _completedLevelNumberText;
    [SerializeField] private Image _artifactLockedImage;

    [Header("Buttons")]
    [Space(10)]
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private void OnEnable()
    {
       // _nextLevelButton.onClick.AddListener(LoadNextLevel);
       // _restartButton.onClick.AddListener(RestartLevel);
       //_mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveAllListeners();
        _restartButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.RemoveAllListeners();
    }

    //public void ShowPopup(bool showArtifact)
    //{
    //    _completedLevelNumberText.text = _loaderService.GetCurrentLevelNumber().ToString();
    //    if (showArtifact)
    //    {
    //        _artifactLockedImage.gameObject.SetActive(false);
    //    }
    //}

    //private void LoadMainMenu() =>
    //    _loaderService.LoadMainMenu();

    //private void LoadNextLevel() => 
    //    _loaderService.LoadNextLevel();

    //private void RestartLevel() => 
    //    _loaderService.ReloadCurrentLevel();
}
