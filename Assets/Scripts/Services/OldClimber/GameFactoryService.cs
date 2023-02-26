using UnityEngine;

public class GameFactoryService
{
    private GameObject _levelCellPrefab;

    public GameFactoryService()
    {
        _levelCellPrefab = Resources.Load<GameObject>(AssetPath.LEVEL_CELL_PREFAB_PATH);
       
    }

    //public void CreateLevels(Transform parent)
    //{
    //    for (int i = 0; i < _levels.Length; i++)
    //    {
    //        _levels[i] = Object.Instantiate(_levelCellPrefab, parent).GetComponent<LevelCell>();
    //    }
    //}

    public LevelCell CreateLevel() =>
        Object.Instantiate(_levelCellPrefab).GetComponent<LevelCell>();

}
