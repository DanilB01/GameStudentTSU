using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    int score;
    int mark;
    public Text scoreTxt;
    public Text markTxt;

    void Start()
    {
        score = PlatfPlayer.coinsCounter;
        scoreTxt.text = score.ToString();
        if (score < 17)
            mark = 3;
        else if (score >= 17 && score <= 21)
            mark = 4;
        else
            mark = 5;
        markTxt.text = mark.ToString();
    }
}
