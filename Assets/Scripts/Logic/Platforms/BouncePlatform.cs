using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField] private int _playerLayer;
    [SerializeField] private int _maxPplatformHealth = 1;
    private int _curPlatformHealth = 1;

    [SerializeField] private float _bounceForce = 1f;

    private Rigidbody2D _rb;

    private void Start() => 
        InitPlatformHealth();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == _playerLayer)
        {
            if (_rb == null)
            {
                _rb = collision.collider.gameObject.GetComponent<Rigidbody2D>();
            }

            BounceUp(_rb);
            UpdatePlatformHealth();

            if (_curPlatformHealth == 0)
            {
                TurnOffBouncer();
            }
        }

    }

    private void BounceUp(Rigidbody2D rb) => 
        rb.AddForce(Vector2.up * _bounceForce, ForceMode2D.Impulse);

    private void UpdatePlatformHealth()
    {
        _curPlatformHealth -= 1;
        _curPlatformHealth = Mathf.Clamp(_curPlatformHealth, 0, _maxPplatformHealth);
    }

    private void TurnOffBouncer() => 
        gameObject.SetActive(false);

    private void InitPlatformHealth() => 
        _curPlatformHealth = _maxPplatformHealth;
}
