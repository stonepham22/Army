using UnityEngine;

public class EnemyAnimation : BaseEnemy
{
    [SerializeField] private Vector2 _lastPosition;
    [SerializeField] private bool _isMoving = false;
    
    void FixedUpdate()
    {
        Vector2 currentPos = Controller.Rigidbody2D.position;
        _isMoving = currentPos != _lastPosition;
        _lastPosition = currentPos;
        if (_isMoving)
        {
            Controller.Animator.Play("Walk");
        }
        else
        {
            Controller.Animator.Play("Idle");
        }
    }

}
