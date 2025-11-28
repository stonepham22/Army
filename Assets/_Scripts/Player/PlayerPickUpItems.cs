using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickUpItems : MonoBehaviour
{
    [SerializeField] private int _gold = 0;
    [SerializeField] private int _iron = 0;
    
    
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
        } else if(item.name.Contains("Iron")) {
            _iron += 1;
        }
    }

}
