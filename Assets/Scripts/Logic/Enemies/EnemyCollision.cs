using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private int _playerLayer;

    public static event Action OnEnemyCollision;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == _playerLayer)
        {
            // Send callback for GameplayState
            OnEnemyCollision?.Invoke();
        }
    }
}
