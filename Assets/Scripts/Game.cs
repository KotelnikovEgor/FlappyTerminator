using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerCharacter _character;
    [SerializeField] private StartGame _startGame;
    [SerializeField] private EndGame _endGame;

    private void Awake()
    {
        Time.timeScale = 0f;
        _startGame.Open();
        _endGame.Close();
    }

    private void OnEnable()
    {
        _startGame.PlayButtonClicked += OnPlayButtonClick;
        _endGame.RestartButtonClicked += OnRestartButtonClick;
        _character.Destroyed += GameOver;
    }

    private void OnDisable()
    {
        _startGame.PlayButtonClicked -= OnPlayButtonClick;
        _endGame.RestartButtonClicked -= OnRestartButtonClick;
        _character.Destroyed -= GameOver;
    }

    private void OnPlayButtonClick()
    {
        _startGame.Close();
        Play();
    }

    private void OnRestartButtonClick()
    {
        _endGame.Close();
        Restart();
    }

    private void Play()
    {
        Time.timeScale = 1f;
    }

    private void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        _endGame.Open();
    }
}
