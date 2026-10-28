using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private LayerMask _layer;

    public event Action Hited;

    private void Awake()
    {
        _inputReader.AttackPressed += Shoot;
    }

    private void OnDestroy()
    {
        _inputReader.AttackPressed -= Shoot;
    }

    private void Shoot()
    {
        Bullet bullet = _bulletSpawner.Spawn(_firePoint.position, _firePoint.right, _layer);
        bullet.EncounteredEnemy += TrackHit;
    }

    private void TrackHit(Bullet bullet)
    {
        Hited?.Invoke();
        bullet.EncounteredEnemy -= TrackHit;
    }
}
