using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private readonly float _horizontalSpeed = -2f;
    private readonly float _verticalSpeed = 2f;
    private readonly float _amplitude = 1f;
    private readonly float _rotationAmplitude = 15f;
    private readonly float _baseYRotation = 180f;

    private float _startYPosition;
    private float _timeCounter;

    public bool IsFalling => Mathf.Cos(_timeCounter) < 0;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, _baseYRotation, 0);
        _startYPosition = transform.position.y;
    }

    private void Update()
    {
        _timeCounter += Time.deltaTime * _verticalSpeed;
        float newXPosition = transform.position.x + _horizontalSpeed * Time.deltaTime;
        float newYPosition = _startYPosition + Mathf.Sin(_timeCounter) * _amplitude;
        transform.position = new Vector3(newXPosition, newYPosition);
        float newZRotation = Mathf.Cos(_timeCounter) * _rotationAmplitude;
        transform.rotation = Quaternion.Euler(0, _baseYRotation, newZRotation);
    }
}
