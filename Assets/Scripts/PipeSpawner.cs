using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject thePipe;  // Initial pipe prefab
    [SerializeField] private bool useRandomPipe = false;  // Flag for random pipe selection
    [SerializeField] private GameObject[] pipeVariants;  // Array for random pipe variants

    private float timer;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        // Decide which pipe to spawn based on useRandomPipe
        GameObject pipeToSpawn = useRandomPipe && pipeVariants.Length > 0
            ? pipeVariants[Random.Range(0, pipeVariants.Length)]  // Random pipe
            : thePipe;  // Default pipe

        // Set the spawn position with random height offset
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange), 0);

        // Instantiate the selected pipe
        GameObject pipe = Instantiate(pipeToSpawn, spawnPos, Quaternion.identity);

        // Destroy the pipe after 10 seconds
        Destroy(pipe, 10f);
    }
}
