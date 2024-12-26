using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
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
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float xPosition = Random.Range(minXAxisSpawnValue, maxXAxisSpawnValue);
        Vector2 spawnPosition = new Vector2(xPosition, yAxisSpawnValue);
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, this.transform);
        timeSinceLastAction = 0f;
        spawnedEnemies.Add(spawnedEnemy);
    }

}
