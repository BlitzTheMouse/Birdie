using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;

    private AudioSource audioSource;
    private Collider2D triggerCollider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        triggerCollider = GetComponent<Collider2D>();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && triggerCollider != null)
        {
            triggerCollider.enabled = false;
        }
    }
}
