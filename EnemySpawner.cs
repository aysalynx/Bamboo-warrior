using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;
    public float spawnY = 0.68f;

    private float timer;
    private float nextSpawn;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextSpawn)
        {
            SpawnEnemy();
            SetNextSpawnTime();
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(12f, spawnY, 0f);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        timer = 0f;
    }

    void SetNextSpawnTime()
    {
        nextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
