using UnityEngine;

public class BossDamage : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private int _health = 250;
    
    public void ReceiveDamage(int damage)
    {
        _health -= damage;
        Debug.Log("Boss received damage: " + damage + ", remaining health: " + _health);
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
