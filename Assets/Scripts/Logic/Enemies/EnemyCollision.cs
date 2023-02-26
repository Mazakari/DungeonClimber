using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private int _playerLayer;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == _playerLayer)
        {
            //Services.SceneLoaderService.ReloadCurrentLevel();
        }
    }
}
