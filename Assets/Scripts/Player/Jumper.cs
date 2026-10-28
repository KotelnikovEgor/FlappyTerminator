using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private readonly float _force = 5f;
    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _inputReader.JumpPressed += Jump;
    }

    private void OnDestroy()
    {
        _inputReader.JumpPressed -= Jump;
    }

    private void Jump()
    {
        _rigidbody.linearVelocityY = _force;
    }

    public void ResetValue()
    {
        _rigidbody.linearVelocity = Vector2.zero;
        transform.position = _startPosition;
    }
}
