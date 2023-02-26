using System;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    private bool _levelStarted = false;

    private ChestKeyPanel _chestKeyPanel;
    private TreasureChest _treasureChest;

    // 'event' Can't be invoked from other class
    public static event Action OnLevelStart;
    public static event Action OnLevelLoaded;

    // Can be invoked from other class
    /// <summary>
    /// Show level results popup. Pass is player got artifact from the chest
    /// </summary>
    public static Action<bool> OnLevelResultShow;

    
    private void OnEnable()
    {
        _chestKeyPanel = FindObjectOfType<ChestKeyPanel>();
        _treasureChest = FindObjectOfType<TreasureChest>();

        FinishPlatform.OnLevelFinish += OnLevelFinish;
    }

    private void Awake() => 
        OnLevelLoaded?.Invoke();

    private void OnDisable() => 
        FinishPlatform.OnLevelFinish -= OnLevelFinish;

    private void Update() =>
       ReadClickOnStartInput();

    private void OnLevelFinish()
    {
        //SaveLevelResults();
        // TO DO save artifact state

        // check if all key being collected
        if (_chestKeyPanel.CheckKeysCollection())
        {
            Debug.Log("Open treasure chest!");
            _treasureChest.OpenChest();
            return;
        }

        Debug.Log("Treasure keys not collected!");
        // Send callback to LevelCanvas to show level complete popup
        OnLevelResultShow?.Invoke(false);
    }

    //private void SaveLevelResults()
    //{
    //    string levelToSave = Services.SceneLoaderService.GetNextLevelName();
    //    Services.SaveLoadService.SaveLevel(levelToSave);
    //    Debug.Log($"Saving {levelToSave}");

    //    // TO DO save level artifact state locked / unlocked
    //    // if it's unlocked do nothing, otherwise way save it's state
    //}

    private void ReadClickOnStartInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_levelStarted)
            {
                _levelStarted = true;

                OnLevelStart?.Invoke();
            }
        }
    }
}
