using UnityEngine;

public class PlayerDamage : MonoBehaviour, IDamageReceiver
{
    
    public void ReceiveDamage(int damage)
    {
        Debug.Log("Player nhận " + damage + " damage.");
    }

}
