using System.Runtime.InteropServices;
using UnityEngine;

public class YandexAPI : MonoBehaviour
{
    public string PlayerIDName { get; private set; }
    public string PlayerAvatarUrl { get; private set; }

    [DllImport("__Internal")]
    private static extern void GetPlayerIDData();

    private void Awake() =>
        DontDestroyOnLoad(this);

    public void GetPlayerData() => 
        GetPlayerIDData();


    public void SetPlayerIDName(string name) => 
        PlayerIDName = name;

    public void SetPlayerIDAvatar(string url) => 
        PlayerAvatarUrl = url;
}
