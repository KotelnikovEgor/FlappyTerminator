using System;
using UnityEngine;

public class PlayerDead : MonoBehaviour, IDamageable
{
    [SerializeField] private Explosion _explosionPrefab;

    private Camera _camera;
    private float _cameraHeight;

    public event Action Dead;

    private void Awake()
    {
        _camera = Camera.main;
        _cameraHeight = _camera.orthographicSize;
    }

    private void Update()
    {
        if (transform.position.y > _cameraHeight || transform.position.y < -_cameraHeight)
            Destroy();
    }

    public void Destroy()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Dead?.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        Destroy();
    }
}
