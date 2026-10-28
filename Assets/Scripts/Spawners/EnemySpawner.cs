using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private BulletSpawner _bulletSpawner;

    private readonly float _xPosition = 12f;
    private readonly float _minYPosition = -4f;
    private readonly float _maxYPosition = 4f;
    private readonly float _spawnRate = 5f;

    private Coroutine _spawnCoroutine;
    private List<Enemy> _enemyList = new();

    private IEnumerator SpawnCoroutine()
    {
        WaitForSeconds seconds = new(_spawnRate);

        while (enabled)
        {
            yield return seconds;
            Vector3 spawnPosition = new(_xPosition, GetRandomYPosition());
            Enemy enemy = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            enemy.Destroyed += RemoveFromList;
            _enemyList.Add(enemy);

            if (enemy.TryGetComponent(out EnemyShoot enemyShoot))
                enemyShoot.SetBulletSpawner(_bulletSpawner);
        }
    }

    private float GetRandomYPosition()
    {
        return Random.Range(_minYPosition, _maxYPosition);
    }

    private void RemoveFromList(Enemy enemy)
    {
        enemy.Destroyed -= RemoveFromList;
        _enemyList.Remove(enemy);
    }

    public override void ResetObjects()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);

        foreach (Enemy enemy in _enemyList)
            Destroy(enemy.gameObject);

        _enemyList.Clear();
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }
}
