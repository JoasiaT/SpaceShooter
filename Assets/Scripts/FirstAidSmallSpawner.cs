using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidSmallSpawner : MonoBehaviour
{
    public GameObject firstAidSmallPrefab;
    public float spawnRate = 6f;
    public float minXAxisSpawnValue = -5f;
    public float maxXAxisSpawnValue = 5f;
    public float yAxisSpawnValue = 4f;

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    private float timeSinceLastAction = 0f;

    void Update()
    {
        timeSinceLastAction += Time.deltaTime;
        if (timeSinceLastAction >= spawnRate)
        {
            SpawnFirstAidSmall();
        }
    }

    void SpawnFirstAidSmall()
    {
        float xPosition = Random.Range(minXAxisSpawnValue, maxXAxisSpawnValue);
        Vector2 spawnPosition = new Vector2(xPosition, yAxisSpawnValue);
        GameObject spawnedEnemy = Instantiate(firstAidSmallPrefab, spawnPosition, Quaternion.identity, this.transform);
        timeSinceLastAction = 0f;
        spawnedEnemies.Add(spawnedEnemy);
    }
}
