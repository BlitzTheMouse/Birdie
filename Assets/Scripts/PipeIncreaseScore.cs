using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Scoring.instance.UpdateScore();

            if (collectSound != null && audioSource != null)
                audioSource.PlayOneShot(collectSound);
        }
    }
}
