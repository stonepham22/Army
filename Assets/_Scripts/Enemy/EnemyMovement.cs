using UnityEngine;

public class EnemyMovement : BaseEnemy
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Vector2 _lastPosition;
    public Vector2 LastPosition => _lastPosition;
    [SerializeField] private float _originalPosition;
    public float OriginalPosition => _originalPosition;
    
    void OnEnable()
    {
        _lastPosition = Controller.Rigidbody2D.position;
        _originalPosition = transform.position.x;
    }
    
    void FixedUpdate()
    {
        Move();
        Flip();
    }
    
    void Move()
    {
        if(Controller.Damage.IsDamaging) return;

        Vector2 targetPos = Controller.ChasePlayer.IsChasing ?
            (Vector2)Controller.Player.position :
            new Vector2(_originalPosition, transform.position.y);

        Vector2 newPos = Vector2.MoveTowards(Controller.Rigidbody2D.position, targetPos, moveSpeed * Time.fixedDeltaTime);
        Controller.Rigidbody2D.MovePosition(newPos);
    }

    void Flip()
    {
        // --- Flip hướng theo chiều di chuyển ---
        Vector2 moveDir = Controller.Rigidbody2D.position - _lastPosition;

        if (moveDir.x > 0.01f)
        {
            // đi sang phải
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDir.x < -0.01f)
        {
            // đi sang trái
            transform.localScale = new Vector3(-1, 1, 1);
        }

        _lastPosition = Controller.Rigidbody2D.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Stop();
        }
    } 

    public void Stop()
    {
        Controller.Rigidbody2D.linearVelocity = Vector2.zero;
    }
}
