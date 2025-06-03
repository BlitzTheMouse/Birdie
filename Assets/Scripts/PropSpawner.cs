using UnityEngine;
using System.Collections.Generic;

public class PropSpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;
    public float spawnInterval = 2f;
    public float moveSpeed = 2f;

    public float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            int index = Random.Range(0, objectsToSpawn.Count);
            GameObject obj = Instantiate(objectsToSpawn[index], transform.position, Quaternion.identity);

            obj.AddComponent<MoveLeft>().speed = moveSpeed;
        }
    }
}

public class MoveLeft : MonoBehaviour
{
    public float speed = 2f;
    public float destroyX = -20f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
