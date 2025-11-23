using UnityEngine;

[RequireComponent(typeof(EnemyGuard2D))]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _damageInterval = 1f;
    [SerializeField] private DamageReceiver _playerHealth;
    [SerializeField] private bool _isDamaging = false;
    public bool IsDamaging => _isDamaging;
    [SerializeField] private EnemyGuard2D _enemyGuard2D;

    void Reset()
    {
        _enemyGuard2D = GetComponent<EnemyGuard2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy chạm vào Player");
            _isDamaging = true;
            _enemyGuard2D.Stop();
            // _playerHealth = collision.GetComponent<DamageReceiver>();

            // if (_playerHealth != null && !_isDamaging)
            // {
            //     _isDamaging = true;
            //     InvokeRepeating(nameof(DealDamage), 0f, _damageInterval);  // bắt đầu gây damage mỗi giây
            // }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy rời khỏi Player");
            _isDamaging = false;
            // StopDamage();
        }
    }

    void DealDamage()
    {
        if (_playerHealth != null)
        {
            _playerHealth.ReceiveDamage(_damage);
            Debug.Log("Enemy gây damage!");
        }
        else
        {
            // Nếu Player biến mất hoặc bị destroy → dừng luôn
            StopDamage();
        }
    }

    void StopDamage()
    {
        _isDamaging = false;
        CancelInvoke("DealDamage");
    }
}
