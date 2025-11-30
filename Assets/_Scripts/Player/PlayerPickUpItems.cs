using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpItems : MonoBehaviour
{
    [SerializeField] private int _gold = 0;
    public int Gold => _gold;
    [SerializeField] private int _iron = 0;
    public int Iron => _iron;

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
        }

        if(other.CompareTag("Supporter")) {
            SupporterInteractPlayer supporter = other.GetComponent<SupporterInteractPlayer>();
            if (supporter != null) {
                if(_gold >= supporter.Gold && _iron >= supporter.Iron) {
                    _gold -= supporter.Gold;
                    _iron -= supporter.Iron;
                    _goldText.text = "Gold: " + _gold.ToString();
                    _ironText.text = "Iron: " + _iron.ToString();
                }
            }
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
