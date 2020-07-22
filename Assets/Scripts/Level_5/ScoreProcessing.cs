using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreProcessing : MonoBehaviour
{
    public Text scoreTxt;
    int score;
    public Text markTxt;
    public int mark;

    public void Update ()
    {
        score = ScoreScript.scoreVal;
        scoreTxt.text = score.ToString();
        if (score >= 12)
            mark = 5;
        else if (score >= 8 && score <= 11)
            mark = 4;
        else if (score >= 6 && score <= 7)
            mark = 3;
        else mark = 2;
        markTxt.text = mark.ToString();
    }
}
