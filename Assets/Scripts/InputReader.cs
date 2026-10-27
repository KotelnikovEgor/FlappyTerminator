using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Fire1 = nameof(Fire1);
    private const string Jump = nameof(Jump);

    public event Action JumpPressed;
    public event Action AttackPressed;

    private void Update()
    {
        if (Input.GetButtonDown(Fire1))
            AttackPressed?.Invoke();

        if (Input.GetButtonDown(Jump))
            JumpPressed?.Invoke();
    }
}
