using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _pauseMenuButtons;


    private void Start()
    {
        _pauseButton.onClick.AddListener(ShowPauseMenuButtons);

        _homeButton.onClick.AddListener(GoToMenuButton);
        _restartButton.onClick.AddListener(RestartLevel);
        _continueButton.onClick.AddListener(HidePauseMenuButtons);
    }


    private void ShowPauseMenuButtons()
    {
        Time.timeScale = 0;
        BallManager.Managed = false;
        _pauseMenuButtons.SetActive(true);
    }
    private void HidePauseMenuButtons()
    {
        StartCoroutine(HiddingPauseMenu());
    }
    private IEnumerator HiddingPauseMenu()
    {

        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;
        BallManager.Managed = true;
        _pauseMenuButtons.SetActive(false);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    private void GoToMenuButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
