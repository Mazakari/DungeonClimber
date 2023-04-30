using System;
using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    [SerializeField] private int _playerLayer;
    [SerializeField] private BoxCollider2D _platformCollider;
    private float _playerMinYOffset = 0.5f;

    public static event Action OnLevelFinish;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == _playerLayer)
        {
            if (PlayerAbovePlatform(collision.collider))
            {
                Debug.Log("Finish");

                // Callback for LevelState
                OnLevelFinish?.Invoke();
            }
               
        }
    }

    private bool PlayerAbovePlatform(Collider2D player)
    {
        float playerMinY = Mathf.Abs(player.bounds.min.y) + _playerMinYOffset;
        float platformMaxY = Mathf.Abs(_platformCollider.bounds.max.y);

        return playerMinY > platformMaxY;
    }
}
