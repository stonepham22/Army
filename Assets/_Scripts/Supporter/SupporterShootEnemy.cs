using Unity.Mathematics;
using UnityEngine;

public class SupporterShootEnemy : MonoBehaviour
{
    [SerializeField] private float shootRange = 10f;
    [SerializeField] private float shootInterval = 0.4f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float shootTimer;
    [SerializeField] private Transform _player;
    [SerializeField] private bool _isShooting;
    public bool IsShooting => _isShooting;

    private void FixedUpdate()
    {
        Vector2 enemy = RaycastFindEnemy();
        if (enemy!= Vector2.zero)
        {
            TryShoot(enemy);
        }
    }

    private Vector2 RaycastFindEnemy()
    {
        // Raycast sang phải
        _isShooting = true;
        
        RaycastHit2D rightHit = Physics2D.Raycast(
            _player.position,
            Vector2.right,
            shootRange,
            enemyLayer
        );

        // Raycast sang trái
        RaycastHit2D leftHit = Physics2D.Raycast(
            _player.position,
            Vector2.left,
            shootRange,
            enemyLayer
        );

        // Nếu cả hai đều thấy enemy → chọn enemy gần nhất
        if (rightHit.collider != null && leftHit.collider != null)
        {
            float rightDist = Vector2.Distance(_player.position, rightHit.point);
            float leftDist  = Vector2.Distance(_player.position, leftHit.point);

            return rightDist < leftDist ? Vector2.right : Vector2.left;
        }

        // Nếu chỉ thấy bên phải
        if (rightHit.collider != null)
            return Vector2.right;

        // Nếu chỉ thấy bên trái
        if (leftHit.collider != null)
            return Vector2.left;

        _isShooting = false;
        // Không có enemy
        return Vector2.zero;
    }

    private void TryShoot(Vector2 enemy)
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            Shoot(enemy);
            shootTimer = shootInterval;
            _isShooting = true;
        }

        _isShooting = false;
    }

    private void Shoot(Vector2 enemyDirection)
    {
        if(enemyDirection == Vector2.left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(enemyDirection == Vector2.right)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        GameObject bullet = Instantiate(bulletPrefab, transform.position, quaternion.identity);
        bullet.GetComponent<BulletSupporter>().direction = enemyDirection;
    }
}
