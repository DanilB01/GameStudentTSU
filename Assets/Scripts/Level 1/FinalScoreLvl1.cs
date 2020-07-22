using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreLvl1 : MonoBehaviour
{
    int mark;
    float score;
    public Text txtScore;
    public Text txtMark;
    public Text Zachet;

    public ScoreManager sm;
    void Update()
    {
        score = math.round(sm.scoreCount);
        txtScore.text = score.ToString();
        if (score > 500)
        {
            mark = 1;
            Zachet.text = "Зачет";
        }
        else
        {
            mark = 0;
            Zachet.text = "Незачет";
        }
        txtMark.text = mark.ToString();
    }
}
