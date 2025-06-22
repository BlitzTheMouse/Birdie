using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScoreButton : MonoBehaviour
{
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);

        if (Scoring.instance != null)
        {
            Scoring.instance.ResetHighScoreUI();
        }
    }
}
