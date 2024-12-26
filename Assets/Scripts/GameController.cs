using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Options()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
