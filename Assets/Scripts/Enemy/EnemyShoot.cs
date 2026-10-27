using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _firePoint;

    private string _bulletLayer = "EnemyBullet";
    private float _rate = 1.5f;
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
            Bullet bullet = Instantiate(_prefab, _firePoint.position, Quaternion.identity);
            bullet.SetDirection(-_firePoint.right);
            bullet.SetLayer(LayerMask.NameToLayer(_bulletLayer));
        }
    }
}
