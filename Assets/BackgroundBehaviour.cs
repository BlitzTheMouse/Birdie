using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public float destroyX = -20f;
    public bool hasSpawnedInitial = false;
    public bool allowRespawn = false;
    public int initialSpawnCount = 3;
    public int respawnCount = 2;

    private float width;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr != null)
            width = sr.bounds.size.x;
        else
            width = 1f;

        if (!hasSpawnedInitial)
        {
            hasSpawnedInitial = true;

            for (int i = 1; i <= initialSpawnCount; i++)
            {
                Vector3 spawnPos = transform.position + Vector3.right * width * i;

                GameObject clone = Instantiate(gameObject, spawnPos, transform.rotation);
                clone.GetComponent<BackgroundBehaviour>().hasSpawnedInitial = true;
                clone.GetComponent<BackgroundBehaviour>().allowRespawn = true;
                clone.GetComponent<BackgroundBehaviour>().initialSpawnCount = initialSpawnCount;
                clone.GetComponent<BackgroundBehaviour>().respawnCount = respawnCount;
            }
        }
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= destroyX)
        {
            if (allowRespawn)
            {
                for (int i = 1; i <= respawnCount; i++)
                {
                    Vector3 spawnPos = transform.position + Vector3.right * width * i;

                    GameObject clone = Instantiate(gameObject, spawnPos, transform.rotation);
                    clone.GetComponent<BackgroundBehaviour>().hasSpawnedInitial = true;
                    clone.GetComponent<BackgroundBehaviour>().allowRespawn = true;
                    clone.GetComponent<BackgroundBehaviour>().initialSpawnCount = initialSpawnCount;
                    clone.GetComponent<BackgroundBehaviour>().respawnCount = respawnCount;
                }
            }

            Destroy(gameObject);
        }
    }
}
