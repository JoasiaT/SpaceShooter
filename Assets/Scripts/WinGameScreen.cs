using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameScreen : MonoBehaviour
{
    public TMP_Text scoreText;

    public void SetWinInfo(int points)
    {
        Time.timeScale = 0;
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
