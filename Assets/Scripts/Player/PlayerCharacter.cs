using System;
using UnityEngine;

[RequireComponent(typeof(PlayerDead))]
public class PlayerCharacter : MonoBehaviour
{
    private PlayerDead _playerDead;

    public event Action Destroyed;

    private void Awake()
    {
        _playerDead = GetComponent<PlayerDead>();
        _playerDead.Dead += ActOnDestroyed;
    }

    private void OnDestroy()
    {
        _playerDead.Dead -= ActOnDestroyed;
    }

    private void ActOnDestroyed()
    {
        Destroyed?.Invoke();
    }
}
