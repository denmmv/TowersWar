using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _restartButtonEnd;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private TextMeshProUGUI _endText;
    // Start is called before the first frame update

    private void Start()
    {
        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _restartButton.onClick.AddListener(RestartGame);
        _restartButtonEnd.onClick.AddListener(RestartGame);
    }
    private void PauseGame()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    private void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PeopleWin()
    {
        Time.timeScale = 0;
        _endScreen.SetActive(true);
        _endText.text = "You win! :)";
    }
    public void AIWin()
    {
        Time.timeScale = 0;
        _endScreen.SetActive(true);
        _endText.text = "You lost! :(";
    }
}
