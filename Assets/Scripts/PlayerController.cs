using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int hp = 3;
    public float moveSpeed = 2f;
    public Transform minXValue;
    public Transform maxXValue;
    public float powerupTime = 10f;

    public GameObject bulletPrefab;
    public Transform gunEndPosition;
    public float fireRate = 0.1f;
    private float timeSinceLastAction = 0f;
    private float halfShipSize = 0.5f;

    public EndGameScreen endGameScreen;

    private AudioManager audioManager;
    private float oldMoveSpeed;
    private float oldFireRate;
    private float tslPowerupModeAction = 0f;
    private bool powerupMode = false;
    public bool shieldEnabed = false;

    public GameObject shield;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        GameManager.playerController = this;
        oldMoveSpeed = moveSpeed;
        oldFireRate = fireRate;
    }

void Update()
    {
        PlayerMovement();
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
        if (hp <= 0)
        {
            endGameScreen.SetEndInfo(GameManager.uiManager.score);
            audioManager.PlaySFX(audioManager.endGameSound);
        }
        if (powerupMode)
        {
            tslPowerupModeAction += Time.deltaTime;
            if (tslPowerupModeAction >= powerupTime)
            {
                moveSpeed = oldMoveSpeed;
                fireRate = oldFireRate;
                powerupMode = false;
            }
        }
    }
    void PlayerMovement()
    {
        float horizontalInputValue = Input.GetAxis("Horizontal");
        Vector2 movomentVector = new Vector2(horizontalInputValue, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movomentVector);
        //if (transform.position.x > maxXValue.position.x)
        //{
        //    transform.position = new Vector2(maxXValue.position.x, transform.position.y);
        //}

        //if (transform.position.x < minXValue.position.x)
        //{
        //    transform.position = new Vector2(minXValue.position.x, transform.position.y);
        //}

        // zmiana ograniczenia obszaru tak, aby by³ niezale¿ny od wielkoœci i formatu ekranu
        // wg: https://www.youtube.com/watch?v=NzSEVjkVPk4&list=PLbghT7MmckI4IeNHkPm5bFJhY9GQ0anKN&index=3

        float screenRatio = (float) Screen.width / Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        Vector2 pos = transform.position;

        if (pos.x+ halfShipSize > widthOrtho)
        {
            pos.x = widthOrtho - halfShipSize;
        }
        if (pos.x - halfShipSize < -widthOrtho)
        {
            pos.x = -widthOrtho + halfShipSize;
        }
        transform.position = pos;
    }

    void Shoot()
    {
        timeSinceLastAction += Time.deltaTime;
        if (timeSinceLastAction >= fireRate)
        {
            Instantiate(bulletPrefab, gunEndPosition.position, Quaternion.identity);
            timeSinceLastAction = 0;
            audioManager.PlaySFX(audioManager.playerShoot);
        }
    }

    public void HittedByBullet()
    {
        if (GameManager.uiManager.powerLevel == 0)
        {
            GameManager.uiManager.DisableHpSprite(hp);
            if (hp > 0)
            {
                hp--;
            }
            GameManager.uiManager.SetFullPowerLevel();
        } 
        else
        {
            GameManager.uiManager.HittedByEnemyBullet();
        }
        DisableShield();
        audioManager.PlaySFX(audioManager.playerExplosion);
    }

    public void HittedByFirstAidSmall()
    {
        GameManager.uiManager.HittedByAidKitSmall();
    }
    public void HittedByFirstAidLarge()
    {
        GameManager.uiManager.HittedByAidKitLarge();
    }

    public void HittedByPowerupBook()
    {
        moveSpeed *= 2f;
        fireRate /= 2f;
        powerupMode = true;
        tslPowerupModeAction = 0f;
    }

    public void HittedByGearUpBig()
    {
        shield.SetActive(true);
        shieldEnabed = true;
    }

    public void DisableShield()
    {
        if (shieldEnabed)
        {
            shield.SetActive(false);
            shieldEnabed = false;
        }
    }
}
