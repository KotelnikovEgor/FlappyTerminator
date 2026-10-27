using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundMover : MonoBehaviour
{
    private float _speed = 2f;
    private float _spriteWidth;

    private void Start()
    {
        _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x <= -_spriteWidth)
        {
            Vector3 newPosition = new(transform.position.x + _spriteWidth * 2f, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
