using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject creditsPanel;
    public float moveDuration = 0.5f;
    public Vector3 hiddenPosition;
    public Vector3 shownPosition;

    private Coroutine moveCoroutine;

    void Start()
    {
        creditsPanel.transform.localPosition = hiddenPosition;
    }

    public void GrassButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BeachButton()
    {
        SceneManager.LoadScene("Beach");
    }

    public void SnowButton()
    {
        SceneManager.LoadScene("Snow");
    }

    public void LakeButton()
    {
        SceneManager.LoadScene("Lake");
    }

    public void CreditsButton()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MovePanel(creditsPanel, shownPosition));
    }

    public void CloseCredits()
    {
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
