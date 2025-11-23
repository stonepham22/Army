using Unity.Mathematics;
using UnityEngine;

public class EnemyGuard2D : MonoBehaviour
{
    [Header("Chase to player")]
    [SerializeField] private Transform _player;
    [SerializeField] private float chaseDistance = 5f;
    [SerializeField] private float stopChaseDistance = 8f;
    [SerializeField] private bool isChasing = false;
    [SerializeField] private EnemyDamage _enemyDamage;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float originalPosition;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _lastPosition;

    [Header("Animation")]
    [SerializeField] private Animator _anim;

    void Reset()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _enemyDamage = GetComponent<EnemyDamage>();
    }

    void OnEnable()
    {
        originalPosition = transform.position.x;
        _lastPosition = _rb.position;
    }

    void FixedUpdate()
    {
        ChasePlayer();
        PlayAnimation();
        Flip();
    }

    void ChasePlayer()
    {
        
        if(_enemyDamage.IsDamaging) return;

        Debug.Log("EnemyGuard2D ChasePlayer()");
        
        float distToPlayer = Vector3.Distance(transform.position, _player.position);

        if (!isChasing && distToPlayer <= chaseDistance)
        {
            isChasing = true;
        }

        if (isChasing && distToPlayer > stopChaseDistance)
        {
            isChasing = false;
        }

        Vector2 targetPos = isChasing ?
            (Vector2)_player.position :
            new Vector2(originalPosition, transform.position.y);

        Vector2 newPos = Vector2.MoveTowards(_rb.position, targetPos, moveSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(newPos);
    }

    void PlayAnimation()
    {   
        
        if(math.abs(_rb.position.x - originalPosition) > 0.1f && !_enemyDamage.IsDamaging)
        {
            _anim.Play("Walk");
        }

        else
        {
            _anim.Play("Idle");
        }

    }

    void Flip()
    {
        // --- Flip hướng theo chiều di chuyển ---
        Vector2 moveDir = _rb.position - _lastPosition;

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

        _lastPosition = _rb.position;
    }

    public void Stop()
    {
        isChasing = false;
        _rb.linearVelocity = Vector2.zero;
        _anim.Play("Idle");
        Debug.Log("EnemyGuard2D Stop()");
    }

}
