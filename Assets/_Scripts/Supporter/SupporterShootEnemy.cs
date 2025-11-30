using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float shootRange = 10f;
    [SerializeField] private float shootInterval = 0.4f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private LayerMask enemyLayer;

    private float shootTimer;

    private void FixedUpdate()
    {
        Transform enemy = RaycastFindEnemy();

        if (enemy != null)
        {
            TryShoot(enemy);
        }
    }

    private Transform RaycastFindEnemy()
    {
        // Raycast sang phải
        shootPoint = transform; // Đảm bảo shootPoint được gán đúng
        RaycastHit2D rightHit = Physics2D.Raycast(
            shootPoint.position,
            Vector2.right,
            shootRange,
            enemyLayer
        );

        // Raycast sang trái
        RaycastHit2D leftHit = Physics2D.Raycast(
            shootPoint.position,
            Vector2.left,
            shootRange,
            enemyLayer
        );

        // Nếu cả hai đều thấy enemy → chọn enemy gần nhất
        if (rightHit.collider != null && leftHit.collider != null)
        {
            float rightDist = Vector2.Distance(shootPoint.position, rightHit.point);
            float leftDist  = Vector2.Distance(shootPoint.position, leftHit.point);

            return rightDist < leftDist ? rightHit.collider.transform : leftHit.collider.transform;
        }

        // Nếu chỉ thấy bên phải
        if (rightHit.collider != null)
            return rightHit.collider.transform;

        // Nếu chỉ thấy bên trái
        if (leftHit.collider != null)
            return leftHit.collider.transform;

        // Không có enemy
        return null;
    }

    private void TryShoot(Transform enemy)
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            Shoot(enemy);
            shootTimer = shootInterval;
        }
    }

    private void Shoot(Transform enemy)
    {
        Debug.Log("Shooting at enemy: " + enemy.name);

        // Tự xác định hướng viên đạn
        // Vector3 dir = enemy.position - shootPoint.position;
        // Quaternion rot = Quaternion.LookRotation(Vector3.forward, dir);
        // Instantiate(bulletPrefab, shootPoint.position, rot);
    }
}
