using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject creditsPanel;
    public float moveDuration = 0.5f;
    public Vector3 hiddenPosition;
    public Vector3 shownPosition;
    public AudioClip clickSound;

    private Coroutine moveCoroutine;
    private AudioSource audioSource;

    void Start()
    {
        creditsPanel.transform.localPosition = hiddenPosition;
        audioSource = GetComponent<AudioSource>();
    }

    void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
            audioSource.PlayOneShot(clickSound);
    }

    public void GrassButton()
    {
        PlayClickSound();
        SceneManager.LoadScene("SampleScene");
    }

    public void BeachButton()
    {
        PlayClickSound();
        SceneManager.LoadScene("Beach");
    }

    public void SnowButton()
    {
        PlayClickSound();
        SceneManager.LoadScene("Snow");
    }

    public void LakeButton()
    {
        PlayClickSound();
        SceneManager.LoadScene("Lake");
    }

    public void CanyonButton()
    {
        PlayClickSound();
        SceneManager.LoadScene("Canyon");
    }

    public void TempleButton()
    {
        PlayClickSound();
        SceneManager.LoadScene("Temple");
    }

    public void CreditsButton()
    {
        PlayClickSound();
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MovePanel(creditsPanel, shownPosition));
    }

    public void CloseCredits()
    {
        PlayClickSound();
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MovePanel(creditsPanel, hiddenPosition, disableAfter: true));
    }

    IEnumerator MovePanel(GameObject panel, Vector3 targetPos, bool disableAfter = false)
    {
        Vector3 startPos = panel.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            panel.transform.localPosition = Vector3.Lerp(startPos, targetPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        panel.transform.localPosition = targetPos;
    }
}
