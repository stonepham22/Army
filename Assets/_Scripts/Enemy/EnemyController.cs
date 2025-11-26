using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    public Transform Player => _player;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    [SerializeField] private Animator _animator;
    public Animator Animator => _animator;
    [SerializeField] private EnemyChasePlayer _enemyChasePlayer;
    public EnemyChasePlayer ChasePlayer => _enemyChasePlayer;
    [SerializeField] private EnemyDamage _enemyDamage;
    public EnemyDamage Damage => _enemyDamage;
    [SerializeField] private EnemyAnimation _enemyAnimation;
    public EnemyAnimation Animation => _enemyAnimation;
    [SerializeField] private EnemyMovement _enemyMovement;
    public EnemyMovement Movement => _enemyMovement;
    
    
    void Reset()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _enemyChasePlayer = GetComponent<EnemyChasePlayer>();
        _enemyDamage = GetComponent<EnemyDamage>();
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _player = GameObject.FindWithTag("Player").transform;

    }
}
