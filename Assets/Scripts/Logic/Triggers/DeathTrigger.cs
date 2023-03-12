using System;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private int _playerLayer;

    public static event Action OnDeadZoneEnter;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == _playerLayer)
        {
            // Send callback for GameplayState
            OnDeadZoneEnter?.Invoke();
        }
    }
}
