using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyGuard2D : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 5f;
    public float stopChaseDistance = 8f;
    public float moveSpeed = 3f;

    [SerializeField] private float originalPosition;
    private bool isChasing = false;
    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalPosition = transform.position.x;

        lastPosition = rb.position;
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.position);

        if (!isChasing && distToPlayer <= chaseDistance)
        {
            isChasing = true;
        }

        if (isChasing && distToPlayer > stopChaseDistance)
        {
            isChasing = false;
        }

        Vector2 targetPos = isChasing ?
            (Vector2)player.position :
            new Vector2(originalPosition, transform.position.y);

        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        PlayAnimation();
        Flip();
    }


    void PlayAnimation()
    {   
        // --- Animation logic using anim.Play ---
        bool isMoving = (rb.position.x != originalPosition);

        

        if (isMoving)
        {
            anim.Play("Walk");
        }
        else
        {
            anim.Play("Idle");
        }

    }

    void Flip()
    {
        // --- Flip hướng theo chiều di chuyển ---
        Vector2 moveDir = rb.position - lastPosition;

        Debug.Log("Move Direction: " + moveDir);


        if (moveDir.x > 0.01f)
        {
            Debug.Log("Flip Right");            
            // đi sang phải
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDir.x < -0.01f)
        {
            Debug.Log("Flip Left");
            // đi sang trái
            transform.localScale = new Vector3(-1, 1, 1);
        }

        lastPosition = rb.position;
    }
}
