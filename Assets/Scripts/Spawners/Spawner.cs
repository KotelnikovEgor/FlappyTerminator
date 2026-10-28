using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : ISpawnable
{
    [SerializeField] protected T _prefab;

    public abstract void ResetObjects();
}
