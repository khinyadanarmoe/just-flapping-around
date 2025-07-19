using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpwanScript : MonoBehaviour
{
    public GameObject rockPrefab;
    public float spawnInterval = 7f;
    public float firstSpawnDelay = 3f; // Delay before first rock spawns
    public float heightOffset = 8f; // Adjust this value to set how high or low the rock can spawn
    private float timer = 0f;
    private bool hasSpawnedFirst = false;
    // Start is called before the first frame update
    void Start()
    {
        // No initial spawn - let the timer handle the first spawn after spawnInterval
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Handle first spawn with separate delay
        if (!hasSpawnedFirst && timer >= firstSpawnDelay)
        {
            SpawnRock();
            hasSpawnedFirst = true;
            timer = 0f; // Reset timer for regular spawning
        }
        // Handle regular spawning after first spawn
        else if (hasSpawnedFirst && timer >= spawnInterval)
        {
            SpawnRock();
            timer = 0f; // Reset timer after spawning
        }
    }

    void SpawnRock()
    {
        // heightOffset means how high or low the rock can spawn
        // where to find heightOffset? In the inspector at the Rock prefab and set it to a value
        float lowestY = transform.position.y - heightOffset; // Adjust this value to set how low the rock spawns
        float highestY = transform.position.y + heightOffset; // Adjust this value to set how high the rock spawns

        Instantiate(rockPrefab, new Vector3(transform.position.x, Random.Range(lowestY, highestY), 0), transform.rotation);
    }
}
