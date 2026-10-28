using System;
using UnityEngine;

public class PlayerDead : MonoBehaviour, IDamageable
{
    [SerializeField] private Explosion _explosionPrefab;

    private Camera _camera;
    private float _cameraHeight;
    private bool _isDead = false;

    public event Action Dead;

    private void Awake()
    {
        _camera = Camera.main;
        _cameraHeight = _camera.orthographicSize;
    }

    private void Update()
    {
        if (_isDead) 
            return;

        if (transform.position.y > _cameraHeight || transform.position.y < -_cameraHeight)
            Die();
    }

    public void Die()
    {
        if (_isDead)
            return;

        _isDead = true;
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Dead?.Invoke();
    }

    public void TakeDamage()
    {
        Die();
    }

    public void ResetValue()
    {
        _isDead = false;
    }
}
