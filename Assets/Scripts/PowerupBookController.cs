using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBookController : MonoBehaviour
{
    public float speed = 0.2f;
    public Transform playerTransform;
    public GameObject powerupBookEffectPrefab;
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
            GameManager.playerController.HittedByPowerupBook();
            //if (powerupBookEffectPrefab != null) // czy gameObject ma podpi�ty efekt
            //{
            //    Instantiate(powerupBookEffectPrefab, transform.position, Quaternion.identity);
            //}
            //if (audioManager != null && audioManager.firstAidLargeSound != null)
            //{
            //    audioManager.PlaySFX(audioManager.firstAidLargeSound);
            //}
            Destroy(gameObject);
        }
    }
}
