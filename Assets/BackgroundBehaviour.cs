using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public float destroyX = -20f;
    public int spawnCount = 1;

    private float width;
    private bool hasSpawned = false;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        width = sr != null ? sr.bounds.size.x : 1f;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (!hasSpawned && transform.position.x <= 0f)
        {
            Vector3 spawnPos = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);

            for (int i = 0; i < spawnCount; i++)
            {
                GameObject clone = Instantiate(gameObject, spawnPos, transform.rotation);
                clone.GetComponent<BackgroundBehaviour>().spawnCount = spawnCount;
                clone.GetComponent<BackgroundBehaviour>().hasSpawned = false;

                spawnPos.x += width;
            }

            hasSpawned = true;
        }

        if (transform.position.x + width < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
