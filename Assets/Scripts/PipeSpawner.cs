using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject thePipe;
    [SerializeField] private bool useRandomPipe = false;
    [SerializeField] private GameObject[] pipeVariants; 

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
        GameObject pipeToSpawn;

        if (useRandomPipe && pipeVariants.Length > 0)
        {
            int index = Random.Range(0, pipeVariants.Length);
            pipeToSpawn = pipeVariants[index];
        }
        else
        {
            pipeToSpawn = thePipe;
        }

        float randomY = Random.Range(-heightRange, heightRange);
        Vector3 spawnPos = transform.position + new Vector3(0, randomY, 0);

        GameObject pipe = Instantiate(pipeToSpawn, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }

}
