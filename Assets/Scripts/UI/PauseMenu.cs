using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject looseMenu;
    [SerializeField] private Initializer _initializer;
    [SerializeField] private FireplaceMainCore _fireplaceMainCore;
    [SerializeField] private TorchMainCore _torchMainCore;
    [SerializeField] private PlayerMainCore _playerMainCore;

    private void Awake()
    {
        _initializer.escapeEvent.AddListener(OnEscape);
    }

    private void FixedUpdate()
    {
        if (_playerMainCore.playerHealth <= 0 || _fireplaceMainCore.fireplaceHealth <= 0)
        {
            Loose();
        }
    }
    private void OnEscape()
    {
        if (GameIsPaused)
        {
            Resume();
        } else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        looseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        looseMenu.SetActive(false);
        pauseMenu.SetActive(false);

        if (_fireplaceMainCore.fireplaceBurnCoroutine != null)
        {
            StopCoroutine(_fireplaceMainCore.fireplaceBurnCoroutine);
            _fireplaceMainCore.fireplaceBurnCoroutine = null;
        }

        if (_torchMainCore.torchBurnCoroutine != null)
        {
            StopCoroutine(_torchMainCore.torchBurnCoroutine);
            _torchMainCore.torchBurnCoroutine = null;
        }

        if (_playerMainCore.freezeDamageCoroutine != null)
        {
            StopCoroutine(_playerMainCore.freezeDamageCoroutine);
            _playerMainCore.freezeDamageCoroutine = null;
        }

        if (_playerMainCore.warmHealCoroutine != null)
        {
            StopCoroutine(_playerMainCore.warmHealCoroutine);
            _playerMainCore.warmHealCoroutine = null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Loose()
    {
        looseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
