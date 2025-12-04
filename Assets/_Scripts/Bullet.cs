using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public Vector2 direction;

    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Xử lý va chạm với enemy hoặc các đối tượng khác
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamageReceiver>()?.ReceiveDamage(20);
            Destroy(gameObject); // Hủy bullet sau khi va chạm        
        }
    }
}
