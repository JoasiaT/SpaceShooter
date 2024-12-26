using UnityEngine;

public class FirstAidSmallController : MonoBehaviour
{
    public float speed = 0.2f;
    public Transform playerTransform;
    public GameObject firstAidEffectPrefab;
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
        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.playerController.HittedByFirstAidSmall();
            if (firstAidEffectPrefab != null) // czy gameObject ma podpiêty efekt
            {
                Instantiate(firstAidEffectPrefab, transform.position, Quaternion.identity);
            }
            if (audioManager != null && audioManager.firstAidSmallSound != null)
            {
                audioManager.PlaySFX(audioManager.firstAidSmallSound);
            }
            Destroy(gameObject);
        }
    }
}
