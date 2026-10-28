using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, ISpawnable
{
    private readonly float _speed = 20f;

    private CircleCollider2D _collider;
    private Rigidbody2D _rigidbody;

    public event Action<Bullet> EncounteredEnemy;
    public event Action<Bullet> Destroyed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out _))
        {
            EncounteredEnemy?.Invoke(this);
        }

        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage();
            Release();
        }
    }

    private void OnBecameInvisible()
    {
        Release();
    }

    private void Release()
    {
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }

    public void Init(Vector3 direction, LayerMask excludeLayer)
    {
        _collider = GetComponent<CircleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _collider.excludeLayers = excludeLayer;
        _rigidbody.linearVelocity = direction.normalized * _speed;
    }
}
