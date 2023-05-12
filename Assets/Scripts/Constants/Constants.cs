
using UnityEngine;

public class Constants
{
    public const string MAIN_MENU_SCENE_NAME = "MainMenu";
    public const string FIRST_LEVEL_NAME = "Level1";
    public const string NEW_PROGRESS_FIRST_LEVEL_SCENE_NAME = "Level1";
    public const string SHOW_YANDEX_RATE_GAME_POPUP_LEVEL = "Level5";

    public static readonly string SAVE_DATA_FOLDER_PATH = $"{Application.dataPath}/Saves";
    public static readonly string SAVE_DATA_PATH = $"{SAVE_DATA_FOLDER_PATH}/save.txt";

    public const string LEVELS_DATA_SO_PATH = "Prefabs/LevelSelection/LevelsDataSO";

    public const string INITIAL_SCENE_NAME = "Initial";
    public const int NEW_PROGRESS_PLAYER_MONEY_AMOUNT = 0;
    //public const string SHOP_SCENE_NAME = "Shop";

    public const string PLAYER_SPAWN_POINT_TAG = "PlayerSpawnPoint";
    //public const string SKINS_TAB_TAG = "Skins Tab";
    //public const string ROPES_TAB_TAG = "Ropes Tab";

    public const string PROGRESS_KEY = "ProgressKey";
}
