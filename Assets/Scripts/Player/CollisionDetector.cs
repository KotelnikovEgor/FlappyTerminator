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
        if (collision.gameObject.TryGetComponent<IInteractable>(out _))
        {
            _playerDead.Die();

            if (collision.gameObject.TryGetComponent(out EnemyDead enemyDead))
                enemyDead.Die();
        }
    }
}
