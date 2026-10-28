using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    private List<Bullet> _bullets = new();

    public Bullet Spawn(Vector3 position, Vector3 direction, LayerMask includeLayer)
    {
        Bullet bullet = Instantiate(_prefab, position, Quaternion.identity);
        bullet.Init(direction, includeLayer);
        bullet.Destroyed += RemoveFromList;
        _bullets.Add(bullet);
        return bullet;
    }

    public override void ResetObjects()
    {
        foreach (Bullet bullet in _bullets)
            Destroy(bullet.gameObject);

        _bullets.Clear();
    }

    private void RemoveFromList(Bullet bullet)
    {
        bullet.Destroyed -= RemoveFromList;
        _bullets.Remove(bullet);
    }
}
