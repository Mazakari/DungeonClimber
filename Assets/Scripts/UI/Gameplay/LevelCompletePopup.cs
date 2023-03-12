using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletePopup : MonoBehaviour
{
    [SerializeField] private Image _artifactLockedImage;

    [Header("Buttons")]
    [Space(10)]
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _restartButton;

    private ISaveLoadService _saveLoadService;
    

    private void OnEnable()
    {
        _saveLoadService = AllServices.Container.Single<ISaveLoadService>();

        _nextLevelButton.onClick.AddListener(LoadNextLevel);
        _restartButton.onClick.AddListener(RestartLevel);

        // SaveProgress
        _saveLoadService.SaveProgress();
    }

    private void RestartLevel() => 
        GameplayCanvas.OnRestartLevel?.Invoke();

    private void LoadNextLevel() => 
        GameplayCanvas.OnNextLevel?.Invoke();

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveAllListeners();
        _restartButton.onClick.RemoveAllListeners();
    }

    public void ShowArtifact(bool locked)
    {
        if (locked)
        {
            _artifactLockedImage.gameObject.SetActive(false);
        }
    }

}
