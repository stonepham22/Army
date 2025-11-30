using UnityEngine;

public class SupporterAnimation : MonoBehaviour
{
    [SerializeField] private Vector2 _lastPosition;
    [SerializeField] private bool _isMoving = false;
    [SerializeField] private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 currentPos = transform.position;
        _isMoving = currentPos != _lastPosition;
        _lastPosition = currentPos;
        if (_isMoving)
        {
            _animator.Play("Walk");
        }
        else
        {
            _animator.Play("Idle");
        }
    }
}
