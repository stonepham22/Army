using UnityEngine;

public class EnemyDamage : MonoBehaviour, IDamageReceiver
{
    [Header("DealDamage")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _damageInterval = 1f;
    [SerializeField] private IDamageReceiver _playerDamage;
    [SerializeField] private bool _isDamaging = false;
    public bool IsDamaging => _isDamaging;

    [Header("ReceiveDamage")]
    [SerializeField] private int _health = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerDamage = collision.GetComponent<IDamageReceiver>();

            if (_playerDamage != null && !_isDamaging)
            {
                _isDamaging = true;
                InvokeRepeating(nameof(DealDamage), 0f, _damageInterval);  // bắt đầu gây damage mỗi giây
            }
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isDamaging = false;
            // StopDamage();
        }
    }

    void DealDamage()
    {
        if (_playerDamage != null)
        {
            _playerDamage.ReceiveDamage(_damage);
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

    public void ReceiveDamage(int damage)
    {
        this._health -= damage;
        if (this._health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
