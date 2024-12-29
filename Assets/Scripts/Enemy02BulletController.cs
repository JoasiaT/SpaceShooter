using UnityEngine;

public class Enemy02BulletController : MonoBehaviour
{
    public float speed = 2f;
    public Transform playerTransform;
    private Vector3 direction;
    public GameObject playerExplosinEffectPrefab;
    public GameObject bulletExplosinEffectPrefab;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        direction = (playerTransform.position - transform.position).normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        DestroyAfterLeftScreen();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.playerController.shieldEnabed)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameManager.playerController.HittedByBullet();
                Instantiate(playerExplosinEffectPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(bulletExplosinEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void DestroyAfterLeftScreen()
    {
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
