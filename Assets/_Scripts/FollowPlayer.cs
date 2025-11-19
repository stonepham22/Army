using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    void Reset()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate() {
        if (_player != null) {
            transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
