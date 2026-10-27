using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Coroutine _rotateCoroutine;
    private float _speed = 2f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, 30);
        _minRotation = Quaternion.Euler(0, 0, -30);
        _inputReader.JumpPressed += Rotate;
    }

    private void OnDestroy()
    {
        _inputReader.JumpPressed -= Rotate;
    }

    private void Rotate()
    {
        if (_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);

        transform.rotation = _maxRotation;
        _rotateCoroutine = StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        yield return new WaitUntil(() => _rigidbody.linearVelocityY <= 0);

        while (Quaternion.Angle(transform.rotation, _minRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _speed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = _minRotation;
        _rotateCoroutine = null;
    }
}
