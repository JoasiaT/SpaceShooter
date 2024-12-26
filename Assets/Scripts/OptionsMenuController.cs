using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
    void Start()
    {
        GameManager.optionsMenuController = this;
    }

    public void ShowOptionsMenu()
    {
        gameObject.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        gameObject.SetActive(false);
    }
}
