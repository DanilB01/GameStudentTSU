using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalButtons : MonoBehaviour
{
    public int lvlNum;
    public void Retry()
    {
        SceneManager.LoadScene(lvlNum);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
