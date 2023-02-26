using System.Collections;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    [Header("Chest")]
    [SerializeField] private SpriteRenderer _closedTreasureChest;
    [SerializeField] private SpriteRenderer _openedTreasureChest;
    [SerializeField] private SpriteRenderer _treasureChestTrophy;

    [Space(10)]
    [Header("Chest locks")]
    [SerializeField] private SpriteRenderer _redTreasureChestLock;
    [SerializeField] private SpriteRenderer _greenTreasureChestLock;
    [SerializeField] private SpriteRenderer _blueTreasureChestLock;

    private float _lockUnlockDelay = 1f;

    private void OnEnable() => 
        InitChest();

    private void OnDisable() => 
        StopCoroutine(ChestOpenCoroutine());

    public void OpenChest() => 
        StartCoroutine(ChestOpenCoroutine());

    private void InitChest()
    {
        _treasureChestTrophy.enabled = false;

        _closedTreasureChest.enabled = true;
        _openedTreasureChest.enabled = false;

        _redTreasureChestLock.enabled = true;
        _greenTreasureChestLock.enabled = true;
        _blueTreasureChestLock.enabled = true;
    }

    private IEnumerator ChestOpenCoroutine()
    {
        bool chestUnlocked = false;
        while (!chestUnlocked)
        {
            yield return new WaitForSeconds(_lockUnlockDelay);
            _redTreasureChestLock.enabled = false;

            yield return new WaitForSeconds(_lockUnlockDelay);
            _greenTreasureChestLock.enabled = false;

            yield return new WaitForSeconds(_lockUnlockDelay);
            _blueTreasureChestLock.enabled = false;

            yield return new WaitForSeconds(_lockUnlockDelay);
            _treasureChestTrophy.enabled = true;

            yield return new WaitForSeconds(_lockUnlockDelay);
            chestUnlocked = true;
            // Send callback to LevelCanvas to open level complete popup
            LevelState.OnLevelResultShow?.Invoke(true);
        }

        yield break;
    }

}
