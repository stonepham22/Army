using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _input;
    [SerializeField] private float _moveSpeed = 5f;

    void Reset()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        GetInput();
        Move();
        PlayAnimation();
    }

    void Update()
    {
        Jump();
    }

    void GetInput()
    {
        _input = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        if(_input==0) return;
        _rigidbody.linearVelocity = new Vector3(_input * _moveSpeed, _rigidbody.linearVelocity.y, 0);
        transform.localScale = new Vector3(Mathf.Sign(Input.GetAxis("Horizontal")), 1, 1);
    }

    void PlayAnimation()
    {
        _animator.Play(_input != 0 ? "Walk" : "Idle");
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }

}
