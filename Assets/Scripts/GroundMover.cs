using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    private float speed;
    private float destroyTime;

    public void Init(float moveSpeed, float timeToDestroy)
    {
        speed = moveSpeed;
        destroyTime = timeToDestroy;
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
