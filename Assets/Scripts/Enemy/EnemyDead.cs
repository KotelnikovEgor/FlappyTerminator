using UnityEngine;

public class EnemyDead : MonoBehaviour, IDamageable
{
    [SerializeField] private Explosion _explosionPrefab;

    private float _positionLimit = -11f;

    private void Update()
    {
        if (transform.position.x < _positionLimit)
            Destroy(gameObject);
    }

    public void Destroy()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        Destroy();
    }
}
