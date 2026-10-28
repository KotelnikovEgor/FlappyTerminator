using System;
using UnityEngine;

public class EnemyDead : MonoBehaviour, IDamageable
{
    [SerializeField] private Explosion _explosionPrefab;

    private readonly float _positionLimit = -11f;

    public event Action Dying;

    private void Update()
    {
        if (transform.position.x < _positionLimit)
            Destroy(gameObject);
    }

    public void Die()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Dying?.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        Die();
    }
}
