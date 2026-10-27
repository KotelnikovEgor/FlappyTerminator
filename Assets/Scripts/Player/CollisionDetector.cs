using UnityEngine;

[RequireComponent(typeof(PlayerDead))]
public class CollisionDetector : MonoBehaviour
{
    private PlayerDead _playerDead;

    private void Awake()
    {
        _playerDead = GetComponent<PlayerDead>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _playerDead.Destroy();

            if (enemy.TryGetComponent(out EnemyDead enemyDead))
                enemyDead.Destroy();
        }
    }
}
