using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
