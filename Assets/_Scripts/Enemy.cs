using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _player;


    void Reset()
    {
        _player = GameObject.FindWithTag("Player");    
    }

    void FixedUpdate()
    {
        // tìm kiếm vị trí player

    }
}
