using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Hàm nhận damage từ object khác
    /// </summary>
    public void ReceiveDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(gameObject.name + " nhận " + damage + " damage. HP còn: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log(gameObject.name + " HP đã về 0.");
        }
    }

    /// <summary>
    /// Hàm xử lý khi chết
    /// </summary>
    private void Die(GameObject killer = null)
    {
        Debug.Log(gameObject.name + " đã chết!");

        // TODO: làm animation chết, hiệu ứng, drop item... tùy bạn
        Destroy(gameObject);
    }
}
