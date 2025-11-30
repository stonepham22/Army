using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpItems : MonoBehaviour
{
    [SerializeField] private int _gold = 0;
    [SerializeField] private int _iron = 0;

    [SerializeField] private Text _goldText;
    [SerializeField] private Text _ironText;

    void Awake()
    {
        _goldText.text = "Gold: " + _gold.ToString();
        _ironText.text = "Iron: " + _iron.ToString();
    }   
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Item")) {
            AddItem(other.gameObject);
            Destroy(other.gameObject);
            // poolingg object
        }

    }

    private void AddItem(GameObject item) {
        if(item.name.Contains("Gold")) {
            _gold += 1;
            _goldText.text = "Gold: " + _gold.ToString();
        } else if(item.name.Contains("Iron")) {
            _iron += 1;
            _ironText.text = "Iron: " + _iron.ToString();
        }
    }

}
