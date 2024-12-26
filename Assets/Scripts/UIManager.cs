using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> hpPointsList;
    public TMP_Text scoreText;
    public int score = 0;
    private int maxScore = 20;
    public int powerLevel; // ilosc "energii"

    public WinGameScreen winGameScreen;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Start()
    {
        GameManager.uiManager = this;
        SetFullPowerLevel();
    }

    public void addScore()
    {
        if (score < maxScore)
        {
            score++;
            scoreText.text = score.ToString();
        } 
        else
        {
            winGameScreen.SetWinInfo(score);
            audioManager.PlaySFX(audioManager.winGameSound);
        }

    }

    public void DisableHpSprite(int value)
    {
        if (value > 0)
        {
            hpPointsList[value - 1].SetActive(false);
        }
    }

    public void EnableHpSprite(int value)
    {
        if (value < 3)
        {
            hpPointsList[value - 1].SetActive(true);
        }
    }

    public void HittedByEnemyBullet()
    {
        if (powerLevel > 0)
        {
            powerLevel-=10;
            GameManager.progressBar.setProgress(powerLevel);
        }
    }

    public void HittedByAidKitSmall()
    {
        if (powerLevel + 10 < 100)
        {
            powerLevel += 10;
            GameManager.progressBar.setProgress(powerLevel);
        }
        else
        {
            SetFullPowerLevel();
        }
    }
    public void HittedByAidKitLarge()
    {
        SetFullPowerLevel();
        if (GameManager.playerController.hp < 3)
        {
            GameManager.playerController.hp++;
            EnableHpSprite(GameManager.playerController.hp);
        }
    }

    public void HittedByEnemy02Bullet()
    {
        if (powerLevel > 0)
        {
            powerLevel-=20;
            GameManager.progressBar.setProgress(powerLevel);
        }
    }

    public void SetFullPowerLevel()
    {
        powerLevel = 100;
        if (GameManager.progressBar != null)
        {
            GameManager.progressBar.setProgress(powerLevel);
        }
    }

    public void SetRestartGame()
    {
        GameManager.playerController.hp = 3;
        GameManager.uiManager.score = 0;
        GameManager.uiManager.SetFullPowerLevel();
    }

}
