using UnityEngine;

public class BossShootPlayer : MonoBehaviour
{
    [SerializeField] private float _shootRange = 15f;
    [SerializeField] private float _shootInterval = 1f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _shootTimer;
    
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

        if(raycastHit2D.collider != null)
        {
            Debug.Log("Player detected by boss!");
            return true;
        }

        return false; // Placeholder
    }

    void ShootAtPlayer()
    {
        Debug.Log("Boss shoots at player!");
    }

}
