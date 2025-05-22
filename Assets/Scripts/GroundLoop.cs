using UnityEngine;
using System.Collections;

public class GroundLoop : MonoBehaviour
{
    public GameObject groundPrefab;

    public float speed = 5f;
    public float spawnInterval = 2f;
    public float destroyTime = 10f;

    void Start()
    {
        SpawnGround(new Vector3(-11f, -5.5f, 0f));
        SpawnGround(new Vector3(3f, -5.5f, 0f));
        SpawnGround(new Vector3(17f, -5.5f, 0f));


        StartCoroutine(StartSpawningAfterDelay(spawnInterval));
    }

    IEnumerator StartSpawningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {
            SpawnGround(transform.position);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnGround(Vector3 spawnPosition)
    {
        GameObject groundClone = Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
        groundClone.AddComponent<GroundMover>().Init(speed, destroyTime);
    }
}
