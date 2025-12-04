using UnityEngine;

public class BossShootPlayer : MonoBehaviour
{
    [SerializeField] private float _shootRange = 15f;
    [SerializeField] private float _shootInterval = 1f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _shootTimer;
    [SerializeField] private CountdownText _countdownText;
    [SerializeField] private bool _isCountingDown = false;
    
    void FixedUpdate()
    {
        if (PlayerInRange())
        {
            ShootAtPlayer();
        }
    }

    private bool PlayerInRange()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(
            transform.position,
            Vector2.left, // Assuming the boss shoots to the right; adjust as needed
            _shootRange,           // Example range; adjust as needed
            _playerLayer // Assuming the player is on the "Player" layer
        );

        if(raycastHit2D.collider == null) return false; 
        
        if(!_isCountingDown)
        {
            _countdownText.StartCountdown();
            _isCountingDown = true;
        }

        return true; // Placeholder
    }

    void ShootAtPlayer()
    {
        _shootTimer += Time.fixedDeltaTime;

        if (_shootTimer <= _shootInterval) return;
        
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().direction = Vector2.left; // Assuming the boss shoots to the left; adjust as needed
        _shootTimer = 0f;

    }

}
