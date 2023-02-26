using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _selectLevelsButton;
    [SerializeField] private Button _clearProgressButton;
    [SerializeField] private Button _quitGameButton;

    [Header("Level Selection Popup")]
    [Space(10)]
    [SerializeField] private GameObject _levelSelectionPopup;
    [SerializeField] private Transform _levelSelectionContent;


    private void OnEnable()
    {
        _levelSelectionPopup.SetActive(false);

        //_startGameButton.onClick.AddListener(LoadLevel);
        //_clearProgressButton.onClick.AddListener(ClearProgress);
        _quitGameButton.onClick.AddListener(QuitGame);
    }

    private void Start()
    {
        //_systemSettingsService = Services.SystemSettingsService;
        //_levelsService = Services.LevelsService;

        //_systemSettingsService.ShowMouseCursor();

        InitLevelsSelectionPopup();
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveAllListeners();
        _clearProgressButton.onClick.RemoveAllListeners();
        _quitGameButton.onClick.RemoveAllListeners();
    }

    public void ShowSelectLevelsPopup() => 
        _levelSelectionPopup.SetActive(true);

    public void HideSelectLevelsPopup() => 
        _levelSelectionPopup.SetActive(false);


    //private void LoadLevel() =>
    //    Services.SaveLoadService.LoadLevel();

    //private void ClearProgress() => 
    //    Services.SaveLoadService.ClearProgress();

    private void QuitGame() => 
        Application.Quit();

    private void InitLevelsSelectionPopup()
    {
        // TO DO load data from SaveLoadService
        //Services.LevelsService.CreateLevels(_levelSelectionContent);
        //Services.LevelsService.InitLevels();

        //for (int i = 0; i < _levelsService.Levels.Length; i++)
        //{
        //    _levelsService.Levels[i].transform.SetParent(_levelSelectionContent);
        //}
    }
}
