using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemySpawnDistance;

    public float startSpawnRate;
    public float minSpawnRate;
    public float timeToMinSpawnRate;

    private float spawnRateMod;

    private float lastSpawnTime;
    private float spawnRate;

    public bool canSpawnEnemy;

    public static EnemySpawner instance;
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        spawnRate = startSpawnRate;
        spawnRateMod = (minSpawnRate - startSpawnRate) / timeToMinSpawnRate;

    }

    // Update is called once per frame
    void Update()
    {
        if (!canSpawnEnemy)
        {
            return;
        }
        if (Time.time - lastSpawnTime >= spawnRate)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        lastSpawnTime = Time.time;

        Vector3 spawnCircle = Random.onUnitSphere;
        spawnCircle.y = Mathf.Abs(spawnCircle.y);

        Vector3 spawnPos = CoreLogic.instance.transform.position + (enemySpawnDistance * spawnCircle);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
