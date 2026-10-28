using System;
using UnityEngine;

[RequireComponent(typeof(EnemyDead))]
public class Enemy : MonoBehaviour, ISpawnable, IInteractable
{
    private EnemyDead _enemyDead;

    public event Action<Enemy> Destroyed;

    private void Awake()
    {
        _enemyDead = GetComponent<EnemyDead>();
        _enemyDead.Dying += InformDie;
    }

    private void OnDestroy()
    {
        _enemyDead.Dying -= InformDie;
    }

    private void InformDie()
    {
        Destroyed?.Invoke(this);
    }
}
