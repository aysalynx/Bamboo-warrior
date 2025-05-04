using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject obstaclePrefab;

    [Header("Spawn interval (in sec)")]
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 7f;

    [Header("Position")]
    public float spawnY = -2.75f;

    private float timer;
    private float nextSpawnTime;

    void Start()
    {
        SetRandomSpawnTime();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnObstacle();
            timer = 0f;
            SetRandomSpawnTime();
        }
    }

    void SetRandomSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void SpawnObstacle()
    {
        float spawnX = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0f, 0f)).x;
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
