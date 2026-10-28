using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayGameWindow _playGame;
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Score _score;

    private void Awake()
    {
        Time.timeScale = 0f;
        _playGame.Open();
    }

    private void OnEnable()
    {
        _playGame.PlayButtonClicked += OnPlayButtonClick;
        _player.Destroyed += GameOver;
    }

    private void OnDisable()
    {
        _playGame.PlayButtonClicked -= OnPlayButtonClick;
        _player.Destroyed -= GameOver;
    }

    private void OnPlayButtonClick()
    {
        _playGame.Close();
        Play();
    }

    private void Play()
    {
        Time.timeScale = 1f;
        _player.ResetValues();
        _enemySpawner.ResetObjects();
        _bulletSpawner.ResetObjects();
        _score.ResetValue();
    }

    private void GameOver()
    {
        _playGame.Open();
    }
}
