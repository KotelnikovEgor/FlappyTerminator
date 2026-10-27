using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;

    private float _xPosition = 12f;
    private float _minYPosition = -4f;
    private float _maxYPosition = 4f;
    private float _spawnRate = 5f;

    private void Awake()
    {
        InvokeRepeating(nameof(Spawn), 0, _spawnRate);
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new(_xPosition, GetRandomYPosition());
        Instantiate(_prefab, spawnPosition, Quaternion.identity);
    }

    private float GetRandomYPosition()
    {
        return Random.Range(_minYPosition, _maxYPosition);
    }
}
