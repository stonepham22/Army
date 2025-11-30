using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public Vector2 direction;


    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
