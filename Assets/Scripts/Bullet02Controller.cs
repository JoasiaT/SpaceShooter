using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02Controller : MonoBehaviour
{
    public float moveSpeed = 9f;
    public float destroyYValue = 5f;

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        DestroyAfterLeftScreen();
    }

    void DestroyAfterLeftScreen()
    {
        if (transform.position.y > destroyYValue)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
