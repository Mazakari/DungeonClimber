using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField] private int _playerLayer;
    [SerializeField] private int _maxPlatformHealth = 1;
    private int _curPlatformHealth = 1;

    [SerializeField] private float _bounceForce = 1f;

    private Rigidbody2D _playerRigidbody2D;

    private void Start() => 
        InitPlatformHealth();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == _playerLayer)
        {
            if (_playerRigidbody2D == null)
            {
                _playerRigidbody2D = collision.collider.gameObject.GetComponent<Rigidbody2D>();
            }

            if (PlayerAbovePlatform(collision.gameObject.transform))
            {
                BounceUp(_playerRigidbody2D);
                UpdatePlatformHealth();

                if (_curPlatformHealth == 0)
                {
                    TurnOffBouncer();
                }
            }
        }
    }

    private void BounceUp(Rigidbody2D rb) => 
        rb.AddForce(Vector2.up * _bounceForce, ForceMode2D.Impulse);

    private void UpdatePlatformHealth()
    {
        _curPlatformHealth -= 1;
        _curPlatformHealth = Mathf.Clamp(_curPlatformHealth, 0, _maxPlatformHealth);
    }

    private void TurnOffBouncer() => 
        gameObject.SetActive(false);

    private void InitPlatformHealth() => 
        _curPlatformHealth = _maxPlatformHealth;

    private bool PlayerAbovePlatform(Transform player)
    {
        float playerYPosition = player.position.y;
        float platformYPosition = transform.position.y;

        return playerYPosition > platformYPosition;
    }
}
