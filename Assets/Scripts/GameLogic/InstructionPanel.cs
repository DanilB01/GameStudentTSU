using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPanel : MonoBehaviour
{
    public int lvlNum;
    void Start()
    {

        if(!DataHolder.isFirstGame[lvlNum - 1])
        {
            gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void CloseInstructionPanel()
    {
        DataHolder.isFirstGame[lvlNum - 1] = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    
}
