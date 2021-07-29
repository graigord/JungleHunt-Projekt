using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions;

public class rock_gen : MonoBehaviour
{

    public Transform smallBoulderPrefab;
    public Transform bigBoulderPrefab;

    private const float boulderSpawnVariance = 0.5f;
    private float boulderSpawnIntervalMin = 3.0f;
    private float boulderSpawnIntervalMax = 5.0f;
    private float nextBoulderSpawnTime = 0.0f;
    private const float firstSpawnTimeOffset = 3.0f;
    private const float lastSpawnTimeOffset = 10.0f;
    private float levelStartTime = 0.0f;
    private const float slopeAngleDegrees = 10.0f;
    private float slopeAngleRadians = slopeAngleDegrees / 360.0f * 2.0f * Mathf.PI;
    private const float groundOffsetY = -4.5f;
    // Start is called before the first frame update
    void Start()
    {

        levelStartTime = Time.time;
        nextBoulderSpawnTime = Time.time + firstSpawnTimeOffset + Random.Range(boulderSpawnIntervalMin, boulderSpawnIntervalMax);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextBoulderSpawnTime)
        {
            SpawnBoulders();
        }
    }
    private void SpawnBoulders()
    {
        Vector2 boulderSpawnPosition = transform.localPosition;

        // Probability that the spawned boulder is small
        const float probabilitySmall = 0.5f;

        // It must be between 0 and 1
        Assert.IsTrue(probabilitySmall >= 0.0f && probabilitySmall <= 1.0f);

        bool boulderIsSmall = (Random.Range(0.0f, 1.0f) <= probabilitySmall ? true : false);

        Transform boulder;

        if (boulderIsSmall)
        {
            boulder = Instantiate(smallBoulderPrefab, boulderSpawnPosition, Quaternion.identity);
        }
        else
        {
            boulder = Instantiate(bigBoulderPrefab, boulderSpawnPosition, Quaternion.identity);
        }


        nextBoulderSpawnTime = Time.time + Random.Range(boulderSpawnIntervalMin, boulderSpawnIntervalMax);
    }
}
