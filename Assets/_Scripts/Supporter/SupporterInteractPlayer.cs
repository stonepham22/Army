using UnityEngine;
using UnityEngine.UI;

public class SupporterInteractPlayer : MonoBehaviour
{
    [SerializeField] private int _gold = 10;
    public int Gold => _gold;
    [SerializeField] private int _iron = 10;
    public int Iron => _iron;
    [SerializeField] private Text _goldText;
    [SerializeField] private Text _ironText;
    [SerializeField] private SupporterFollowPlayer _supporterFollowPlayer;

    void Awake()
    {
        _goldText.text = "Gold Req: " + _gold.ToString();
        _ironText.text = "Iron Req: " + _iron.ToString();
        _supporterFollowPlayer = GetComponent<SupporterFollowPlayer>();
        _supporterFollowPlayer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPickUpItems playItem = other.GetComponent<PlayerPickUpItems>();
            if (playItem != null)
            {
                if(_gold <= playItem.Gold && _iron <= playItem.Iron)
                {
                    _goldText.transform.gameObject.SetActive(false);
                    _ironText.transform.gameObject.SetActive(false);
                    _supporterFollowPlayer.enabled = true;
                }
            }
        }
    }

}
