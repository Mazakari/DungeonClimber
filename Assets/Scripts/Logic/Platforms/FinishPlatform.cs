using System;
using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    [SerializeField] private int _playerLayer;

    public static event Action OnLevelFinish;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == _playerLayer)
        {
            if (PlayerAbovePlatform(collision.gameObject.transform))
            {
                Debug.Log("Finish");

                // Callback for LevelState
                OnLevelFinish?.Invoke();
            }
               
        }
    }

    private bool PlayerAbovePlatform(Transform player)
    {
        float playerYPosition = player.position.y;
        float platformYPosition = transform.position.y;

        return playerYPosition > platformYPosition;
    }
}
