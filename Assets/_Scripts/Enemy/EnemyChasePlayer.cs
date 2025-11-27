using Unity.Mathematics;
using UnityEngine;

public class EnemyChasePlayer : BaseEnemy
{
    [Header("Chase to player")]
    [SerializeField] private float chaseDistance = 5f;
    [SerializeField] private float stopChaseDistance = 8f;
    [SerializeField] private bool isChasing = false;
    public bool IsChasing => isChasing;

    void FixedUpdate()
    {
        Chase();
    }

    /// <summary>
    /// Thực hiện chắc năng đuổi theo người chơi
    /// </summary>
    void Chase()
    {
        
        if(Controller.Damage.IsDamaging) return;

        float distToPlayer = Vector3.Distance(transform.position, Controller.Player.position);

        if (!isChasing && distToPlayer <= chaseDistance)
        {
            isChasing = true;
        }

        if (isChasing && distToPlayer > stopChaseDistance) isChasing = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false;
        }
    } 

}
