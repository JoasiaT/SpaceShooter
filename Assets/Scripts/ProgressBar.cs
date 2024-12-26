using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressSlider;

    void Start()
    {
        GameManager.progressBar = this;
        progressSlider.value = 1;
    }

    public void setProgress(int value)
    {
        progressSlider.value = (float) value / 100;
    }
}
