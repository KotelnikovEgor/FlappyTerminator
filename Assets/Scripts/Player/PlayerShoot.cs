using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _firePoint;

    private string _bulletLayer = "PlayerBullet";

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
        Bullet bullet = Instantiate(_prefab, _firePoint.position, Quaternion.identity);
        bullet.SetDirection(_firePoint.right);
        bullet.SetLayer(LayerMask.NameToLayer(_bulletLayer));
        bullet.EncounteredEnemy += TrackHit;
    }

    private void TrackHit(Bullet bullet)
    {
        Hited?.Invoke();
        bullet.EncounteredEnemy -= TrackHit;
    }
}
