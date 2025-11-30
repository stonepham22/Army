using UnityEngine;

public class SupporterFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followDistance = 2f;
    [SerializeField] private float moveSpeed = 3f;

    private void FixedUpdate()
    {
        FollowPlayerBehind();
        FlipTowardsPlayer();
    }

    private void FollowPlayerBehind()
    {
        // xác định hướng nhìn của player
        float playerDirection = Mathf.Sign(player.localScale.x);

        // vị trí đứng phía sau player
        float targetX = player.position.x - playerDirection * followDistance;

        Vector2 targetPos = new Vector2(targetX, transform.position.y);

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );
    }

    private void FlipTowardsPlayer()
    {
        // nếu player ở bên phải -> flip phải
        // nếu player ở bên trái -> flip trái
        float dirToPlayer = Mathf.Sign(player.position.x - transform.position.x);

        transform.localScale = new Vector3(dirToPlayer, 1, 1);
    }
}
