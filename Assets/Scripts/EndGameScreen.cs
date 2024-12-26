using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
    public TMP_Text scoreText;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void SetEndInfo(int points)
    {
        Time.timeScale = 0;
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.endGameSound);
        }
        gameObject.SetActive(true);
        scoreText.text = points.ToString();
    }

    public void RestartGame()
    {
        GameManager.uiManager.SetRestartGame();
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }

    public void MainMenu()
    {
        GameManager.uiManager.SetRestartGame();
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
