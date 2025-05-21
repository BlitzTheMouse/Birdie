using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private AudioSource audioSource;


    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        audioSource.PlayOneShot(hitSound);


        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        var player = FindObjectOfType<FlyBehaviour>();
        if (player != null)
            player.UnmuteAudio();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ToTheMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
