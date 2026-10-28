using System;
using UnityEngine;

[RequireComponent(typeof(Jumper), typeof(Rotator), typeof(PlayerDead))]
[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D), typeof(PlayerShoot))]
public class Player : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private Jumper _jumper;
    private Rotator _rotator;
    private PlayerShoot _playerShoot;
    private PlayerDead _playerDead;

    public event Action Destroyed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _jumper = GetComponent<Jumper>();
        _rotator = GetComponent<Rotator>();
        _playerShoot = GetComponent<PlayerShoot>();
        _playerDead = GetComponent<PlayerDead>();
        _playerDead.Dead += DisableComponents;
    }

    private void OnDestroy()
    {
        _playerDead.Dead -= DisableComponents;
    }

    private void DisableComponents()
    {
        _spriteRenderer.enabled = false;
        _collider.enabled = false;
        _jumper.enabled = false;
        _playerShoot.enabled = false;
        Destroyed?.Invoke();
    }

    public void ResetValues()
    {
        _jumper.ResetValue();
        _rotator.ResetValue();
        _playerDead.ResetValue();

        _spriteRenderer.enabled = true;
        _collider.enabled = true;
        _jumper.enabled = true;
        _playerShoot.enabled = true;
    }
}
