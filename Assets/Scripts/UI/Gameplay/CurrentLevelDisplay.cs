using TMPro;
using UnityEngine;

public class CurrentLevelDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _numberText;
    private int _number;

    private void OnEnable()
    {
        SetCurrentLevel();
    }

    private void SetCurrentLevel()
    {
       // _number = Services.SceneLoaderService.GetCurrentLevelNumber();
        _numberText.text = _number.ToString();
    }
}
