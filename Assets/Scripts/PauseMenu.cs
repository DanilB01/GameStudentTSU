using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    static bool IsPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPaused)
            {
                OpenPanel();
                IsPaused = true;
            }
            else
            {
                ClosePanel();
            }
            
        }
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        ClosePanel();
    }
    private void OpenPanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        pausePanel.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1;
    }
}
