using System;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private int _playerLayer;

    [Space(10)]
    [Header("Audio")]
    [SerializeField] private ItemSound _itemSound;

    public static event Action OnDeadZoneEnter;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == _playerLayer)
        {
            _itemSound.Play();
            // Send callback for GameplayState
            OnDeadZoneEnter?.Invoke();
        }
    }
}
