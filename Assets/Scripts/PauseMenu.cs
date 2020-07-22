using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    static bool IsPaused = false;
    public int lvlNum;
    public GameObject MarkPanel;
    bool IsPressed = false;
    public static bool isPausedForLevels = false;
    public static bool isPauseDeniedForLevels = false;

    private void Start()
    {
        isPausedForLevels = false;
        isPauseDeniedForLevels = false;
}
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!IsPressed)
            {
                MarkPanel.SetActive(true);
                IsPressed = true;
            }
            else
            {
                MarkPanel.SetActive(false);
                IsPressed = false;
            }
        }
    }
    public void ExitGame()
    {
        if(lvlNum > 0)
            DataHolder.isFoodNeed[lvlNum - 1] = true;
        switch (lvlNum)
        {
            case 0:
                SceneManager.LoadScene("MainMenu");
                break;
            case 1:
                Marks.passMarks[0] = 2;
                Translator.fromLevel = 0;
                SceneManager.LoadScene("TSUmap");
                break;
            case 2:
                Marks.passMarks[1] = 2;
                Translator.fromLevel = 1;
                SceneManager.LoadScene("SecondCampus");
                break;
            case 3:
                Marks.passMarks[2] = 2;
                Translator.fromLevel = 2;
                Time.timeScale = 1;
                SceneManager.LoadScene("TSUmap");
                break;
            case 4:
                Marks.passMarks[3] = 2;
                Translator.fromLevel = 3;
                SceneManager.LoadScene("TSUmap");
                break;
            case 5:
                Marks.passMarks[4] = 2;
                Translator.fromLevel = 4;
                SceneManager.LoadScene("TSUmap");
                break;
            case 6:
                Marks.examMarks[1] = 2;
                Translator.fromLevel = 5;
                SceneManager.LoadScene("SecondCampus");
                break;
            case 7:
                Marks.examMarks[2] = 2;
                Translator.fromLevel = 6;
                SceneManager.LoadScene("TSUmap");
                break;
            case 8:
                Marks.examMarks[0] = 2;
                Translator.fromLevel = 7;
                SceneManager.LoadScene("SecondCampus");
                break;
        }
        ClosePanel();
    }
    private void OpenPanel()
    {
        pausePanel.SetActive(true);
        isPausedForLevels = true;
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        pausePanel.SetActive(false);
        IsPaused = false;
        isPauseDeniedForLevels = true;
        isPausedForLevels = false;
        Time.timeScale = 1;
    }
}
