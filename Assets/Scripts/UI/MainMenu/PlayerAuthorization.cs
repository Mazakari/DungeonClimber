using UnityEngine;

public class PlayerAuthorization : MonoBehaviour
{
    [SerializeField] private GameObject _authorizePlayer;
    [SerializeField] private GameObject _playerYandexID;

    private IYandexService _yandexService;

    private void OnEnable()
    {
        _yandexService = AllServices.Container.Single<IYandexService>();

        // TO DO Remove after build success
        _authorizePlayer.SetActive(false);
        _playerYandexID.SetActive(false);

#if !UNITY_EDITOR
       InitAuthDisplay();
       _yandexService.API.OnAuthorizedStatusResponse += ShowAuthState;
#endif
    }

    private void OnDisable()
    {
#if !UNITY_EDITOR
       _yandexService.API.OnAuthorizedStatusResponse -= ShowAuthState;
#endif
    }

    private void ShowAuthState()
    {
        bool authorized = _yandexService.API.PlayerLoggedIn;

        _authorizePlayer.SetActive(!authorized);
        _playerYandexID.SetActive(authorized);

        Debug.Log($"PlayerAuthorization.ShowAuthState Player authorized = {authorized}");
    }

    private void InitAuthDisplay()
    {
        _authorizePlayer.SetActive(true);
        _playerYandexID.SetActive(false);
    }
}
