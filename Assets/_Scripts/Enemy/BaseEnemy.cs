using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [Header("Base Enemy")]
    [SerializeField] private EnemyController _enemyController;
    protected EnemyController Controller => _enemyController;

    protected virtual void Reset()
    {
        _enemyController = GetComponent<EnemyController>();
    }
}
