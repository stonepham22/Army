using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _damage = 20;
    public Vector2 direction;

    void FixedUpdate()
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamageReceiver>()?.ReceiveDamage(_damage);
        Destroy(gameObject); // Hủy bullet sau khi va chạm      
    }
}
