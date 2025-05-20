using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{

    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float tiltUpAngle = 25f;
    [SerializeField] private float tiltDownSpeed = 5f;

    private Rigidbody2D rb;
    private float currentRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.velocity = Vector2.up * velocity;
            currentRotation = tiltUpAngle;
        }
    }

    void FixedUpdate()
    {
        currentRotation = Mathf.Lerp(currentRotation, -90f, tiltDownSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }
}
