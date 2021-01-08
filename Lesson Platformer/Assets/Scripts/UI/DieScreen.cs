using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class DieScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.Die += OnPlayerDied;
        _restartButton.onClick.AddListener(OnRestartButtonPressed);
        _quitButton.onClick.AddListener(OnQuitButtonPressed);
    }

    private void OnDisable()
    {
        _player.Die -= OnPlayerDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonPressed);
        _quitButton.onClick.RemoveListener(OnQuitButtonPressed);
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnPlayerDied()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    private void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
