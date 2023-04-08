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

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _sprite;

    public static event Action<KeyType> OnKeyPickup;

    private void OnEnable() => 
        SetSprite();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == _playerLayer)
        {
            gameObject.SetActive(false);

            // Callback for ChestKeyPanel
            OnKeyPickup?.Invoke(_type);
        }
    }
    private void SetSprite()
    {
        if (_sprite == null || _spriteRenderer == null)
        {
            Debug.LogError("Sprite renderer or sprite reference not set");
            return;
        }

        _spriteRenderer.sprite = _sprite;
    }
}
