using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalButtons : MonoBehaviour
{
    public Text fromWhatTakeResult;
    public string lvlName;
    public int lvlNum;
    public void Retry()
    {
        SceneManager.LoadScene(lvlName);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        DataHolder.isFoodNeed[lvlNum - 1] = true;
        switch (lvlNum)
        {
            case 1:
                Marks.passMarks[0] = int.Parse(fromWhatTakeResult.text);
                Translator.fromLevel = 0;
                break;
            case 2:
                Marks.passMarks[1] = int.Parse(fromWhatTakeResult.text);
                Translator.fromLevel = 1;
                break;
            case 3:
                Marks.passMarks[2] = int.Parse(fromWhatTakeResult.text);
                Translator.fromLevel = 2;
                break;
            case 4:
                Marks.passMarks[3] = int.Parse(fromWhatTakeResult.text);
                Translator.fromLevel = 3;
                break;
            case 5:
                Marks.passMarks[4] = int.Parse(fromWhatTakeResult.text);
                Translator.fromLevel = 4;
                break;
            case 6:
                Marks.examMarks[1] = int.Parse(fromWhatTakeResult.text);
                Translator.fromLevel = 5;
                break;
            case 7:
                Marks.examMarks[2] = int.Parse(fromWhatTakeResult.text);
                Translator.fromLevel = 6;
                break;
            case 8:
                Marks.examMarks[0] = int.Parse(fromWhatTakeResult.text);
                Translator.fromLevel = 7;
                break;
        }
        if(lvlName == "Level 2" ||
           lvlName == "Level 6" ||
           lvlName == "Level 8"
           )
        {
            SceneManager.LoadScene("SecondCampus");
        }
        else
            SceneManager.LoadScene("TSUmap");
        Time.timeScale = 1;
    }
}
