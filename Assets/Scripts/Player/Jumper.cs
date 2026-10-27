using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody;
    private float _force = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader.JumpPressed += Jump;
    }

    private void OnDisable()
    {
        _inputReader.JumpPressed -= Jump;
    }

    private void Jump()
    {
        _rigidbody.linearVelocityY = _force;
    }
}
