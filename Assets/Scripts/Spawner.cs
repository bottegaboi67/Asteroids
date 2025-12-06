using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 1.5f;

    public float spawnDistance = 7f;

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 1f, spawnInterval);
    }

    void SpawnAsteroid()
    {
        float angle = Random.Range(0f, 360f);
        Vector3 spawnPos = new Vector3(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),
            0f
        ) * spawnDistance;

        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}
