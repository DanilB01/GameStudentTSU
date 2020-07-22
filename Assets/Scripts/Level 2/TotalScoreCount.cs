using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScoreCount : MonoBehaviour
{
    int Score, Mark;
    public Text ScrTxt, MrkTxt, ResultTxt;

    void Update()
    {
        Score = GenMemes.Score;

        Score *= 5;

        ScrTxt.text = Score.ToString() + "%";

        if(Score > 50)
        {
            Mark = 1;
            ResultTxt.text = "Зачет";
        }
        else
        {
            Mark = 0;
            ResultTxt.text = "Незачет";
        }

        MrkTxt.text = Mark.ToString();
    }
}
