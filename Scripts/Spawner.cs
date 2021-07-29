using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour
{
    public Transform SwimmingEnemyPrefab;
    private float SwimmingEnemySpawnIntervalMin = 1.0f;
    private float SwimmingEnemySpawnIntervalMax = 3.0f;
    private float nextSwimmingEnemySpawnTime = 0.0f;
    private const float firstSwimmingEnemySpawnTimeOffset = 1.0f;
    private const float lastSwimmingEnemyTimeOffset = 10.0f;
    private float levelStartTime = 0.0f;
    float RandY;
    // Start is called before the first frame update
    void Start()
    {
        levelStartTime = Time.time;
        nextSwimmingEnemySpawnTime = Time.time + firstSwimmingEnemySpawnTimeOffset + Random.Range(SwimmingEnemySpawnIntervalMin,SwimmingEnemySpawnIntervalMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSwimmingEnemySpawnTime)
        {
            SpawnSwimmingEnemy();
        }
        transform.position = transform.position + new Vector3(-.007f, 0, 0);


    }
    private void SpawnSwimmingEnemy()
    {
        RandY = Random.Range(-1.2f, 0.23f);
        if (transform.position.x >= -13)
        {

            Vector2 SwimmingEnemyPosition = new Vector2(transform.position.x, RandY);

            Transform SwimmingEnemy;

            SwimmingEnemy = Instantiate(SwimmingEnemyPrefab, SwimmingEnemyPosition, Quaternion.identity);

            nextSwimmingEnemySpawnTime = Time.time + Random.Range(SwimmingEnemySpawnIntervalMin, SwimmingEnemySpawnIntervalMax);
        }
    }


}
