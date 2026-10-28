using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private LayerMask _layer;

    private BulletSpawner _bulletSpawner;
    private readonly float _rate = 1.5f;
    private WaitForSeconds _rateInSeconds;

    private void Start()
    {
        _rateInSeconds = new(_rate);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            yield return _rateInSeconds;
            _bulletSpawner.Spawn(_firePoint.position, -_firePoint.right, _layer);
        }
    }

    public void SetBulletSpawner(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
    }
}
