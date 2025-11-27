using UnityEngine;

public class PlayerDamage : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private int _health = 100;
    
    
    public void ReceiveDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"Player nhận {damage} damage. Máu còn lại: {_health}");
        if (_health <= 0)
        {
            Debug.Log("Player đã chết!");
            // Xử lý khi Player chết (ví dụ: phát hiệu ứng, chuyển cảnh, v.v.)
        }
    }

}
