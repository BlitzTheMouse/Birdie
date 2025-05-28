using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatMotion : MonoBehaviour
{
    public float height = 1f;
    public float speed = 1f;
    public AudioClip chirpClip;

    private Vector3 startPos;
    private float timer;
    private AudioSource audioSource;

    void Start()
    {
        startPos = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime * speed;

        float t = (Mathf.Sin(timer) + 1f) / 2f;
        float eased = Mathf.SmoothStep(0f, 1f, t);
        float yOffset = Mathf.Lerp(-height, height, eased);

        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }

    void OnMouseDown()
    {
        if (chirpClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(chirpClip);
        }
    }
}
