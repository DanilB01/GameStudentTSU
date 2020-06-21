using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    
    public void RestartScene()
    {
        SceneManager.LoadScene("Level 5");
        ScoreScript.scoreVal = 0;
        Time.timeScale = 1;
        timeLeftCounter.timeLeft = 180f;
    }
}
