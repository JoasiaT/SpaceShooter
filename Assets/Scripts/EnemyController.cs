using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.6f;
    public Transform playerTransform;
    public float fireRate = 1f;
    private float timeSinceLastAction = 0f;
    public GameObject bulletPrefab;
    public Transform enemyGunEnd;
    public GameObject enemyExplosinEffectPrefab;
    public GameObject playerExplosinEffectPrefab;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        GameObject palyerGameObject = GameObject.Find("Player");
        playerTransform = palyerGameObject.transform;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y > -1.5f)
        {
            Shoot();
        }

        if (transform.position.y < -5.5f)
        {
            GameManager.playerController.HittedByBullet();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameManager.uiManager.addScore();
            audioManager.PlaySFX(audioManager.enemyExplosion);
            Instantiate(enemyExplosinEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            GameManager.playerController.HittedByBullet();
            Instantiate(playerExplosinEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

     void Shoot()
     {
           timeSinceLastAction += Time.deltaTime;
           if (timeSinceLastAction >= fireRate)
           {
                Instantiate(bulletPrefab, enemyGunEnd.position, Quaternion.identity);
                timeSinceLastAction = 0;
           }
     }

}
