using System;
using UnityEngine;

public enum KeyType
{
    Red,
    Green,
    Blue,
}

public class ChestKey : MonoBehaviour
{
    [SerializeField] private KeyType _type;
    [SerializeField] private int _playerLayer;

    public static event Action<KeyType> OnKeyPickup;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == _playerLayer)
        {
            gameObject.SetActive(false);

            // Callback for ChestKeyPanel
            OnKeyPickup?.Invoke(_type);
        }
    }
}
