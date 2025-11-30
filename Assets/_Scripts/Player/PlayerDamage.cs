using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private int _health = 100;
    public GameObject gameOverScreen;
    public Text HpText;

    void Awake()
    {
        HpText.text = "HP: " + _health.ToString();
    }

    public void ReceiveDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Debug.Log("Player đã chết!");
            gameOverScreen.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        HpText.text = "HP: " + _health.ToString();
    }

}
