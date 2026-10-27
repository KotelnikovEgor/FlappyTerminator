using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 20f;
    private float _lifeTime = 5f;
    private WaitForSeconds _lifeInSeconds;
    private Vector3 _direction;
    private Coroutine _lifeTimerCoroutine;

    public event Action<Bullet> EncounteredEnemy;

    private void Awake()
    {
        _lifeInSeconds = new(_lifeTime);
        _lifeTimerCoroutine = StartCoroutine(LifeTimer());
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out _))
        {
            EncounteredEnemy?.Invoke(this);
        }

        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage();
            StopCoroutine(_lifeTimerCoroutine);
            Destroy(gameObject);
        }
    }

    private IEnumerator LifeTimer()
    {
        yield return _lifeInSeconds;
        Destroy(gameObject);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    public void SetLayer(int layerIndex)
    {
        gameObject.layer = layerIndex;
    }
}
