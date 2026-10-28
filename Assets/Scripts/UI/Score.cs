using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour
{
    [SerializeField] private PlayerShoot _playerShoot;

    private TextMeshProUGUI _text;
    private int _number = 0;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _playerShoot.Hited += Add;
    }

    private void OnDestroy()
    {
        _playerShoot.Hited -= Add;
    }

    private void Add()
    {
        _number++;
        _text.text = _number.ToString();
    }

    public void ResetValue()
    {
        _number = 0;
        _text.text = _number.ToString();
    }
}
