using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private int _playerLayer;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == _playerLayer)
        {
            //AllServices.Container.Single<>SceneLoaderService.ReloadCurrentLevel();
        }
    }
}
