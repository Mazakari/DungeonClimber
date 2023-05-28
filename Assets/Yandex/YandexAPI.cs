using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexAPI : MonoBehaviour
{
    public string PlayerIDName { get; private set; }
    public string PlayerAvatarUrl { get; private set; }
    public string PlayerProgress { get; private set; }

    [DllImport("__Internal")]
    private static extern void GetPlayerIDData();

    [DllImport("__Internal")]
    private static extern void RateGame();

    [DllImport("__Internal")]
    private static extern void SavePlayerDataToYandex(string playerData);

    [DllImport("__Internal")]
    private static extern void LoadPlayerDataFromYandex();

    public event Action OnYandexProgressCopied;

    [DllImport("__Internal")]
    private static extern void UpdateLeaderboardData(int newMaxLevel);

    [DllImport("__Internal")]
    private static extern string GetSystemLanguage();


    private void Awake() =>
        DontDestroyOnLoad(this);

    public void GetPlayerData() => 
        GetPlayerIDData();

    public void ShowRateGamePopup() => 
        RateGame();

    public void SetPlayerIDName(string name) => 
        PlayerIDName = name;

    public void SetPlayerIDAvatar(string url) => 
        PlayerAvatarUrl = url;

    public void SaveToYandex(string progress)
    {
        Debug.Log($"SaveToYandex.progress = {progress}");
        SavePlayerDataToYandex(progress);
    }

    public void LoadFromYandex() => 
        LoadPlayerDataFromYandex();

    public void CopyYandexProgress(string progress)
    {
        PlayerProgress = progress;

        OnYandexProgressCopied?.Invoke();
    }

    public void SaveYandexLeaderboard(int newMaxLevel)
    {
        Debug.Log($"Sending new max level {newMaxLevel} to Yandex leaderboard");
        UpdateLeaderboardData(newMaxLevel);
    }

    public string GetPlatformLanguage() =>
        GetSystemLanguage();

}
