using System.Collections.Generic;
using UnityEngine;

public class Enemy02Spawner : MonoBehaviour
{
    public GameObject enemy02prefab;
    public float spawnRate = 2f;
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
            SpawnEnemy02();
        }
    }

    void SpawnEnemy02()
    {
        float xPosition = Random.Range(minXAxisSpawnValue, maxXAxisSpawnValue);
        Vector2 spawnPosition = new Vector2(xPosition, yAxisSpawnValue);
        GameObject spawnedEnemy = Instantiate(enemy02prefab, spawnPosition, Quaternion.identity, this.transform);
        timeSinceLastAction = 0f;
        spawnedEnemies.Add(spawnedEnemy);
    }
}
