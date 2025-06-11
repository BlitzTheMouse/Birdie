using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFloatMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDuration = 2f;
    public float deceleration = 2f;

    public float height = 1f;
    public float floatSpeed = 1f;

    private Vector3 startPos;
    private float moveTimer = 0f;
    private float floatTimer = 0f;
    private float currentSpeed;
    private bool slowingDown = false;

    void Start()
    {
        startPos = transform.position;
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        moveTimer += Time.deltaTime;

        if (moveTimer >= moveDuration)
        {
            slowingDown = true;
        }

        if (slowingDown)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * deceleration);
        }

        floatTimer += Time.deltaTime * floatSpeed;
        float t = (Mathf.Sin(floatTimer) + 1f) / 2f;
        float eased = Mathf.SmoothStep(0f, 1f, t);
        float yOffset = Mathf.Lerp(-height, height, eased);

        Vector3 offset = new Vector3(currentSpeed * Time.deltaTime, yOffset, 0f);
        transform.position = startPos + offset;

        startPos += new Vector3(currentSpeed * Time.deltaTime, 0f, 0f); // track horizontal movement
    }

}
