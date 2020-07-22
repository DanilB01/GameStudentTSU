using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text txt;
    public float timeLeft;

    WordsSpawner wsCode;
    WordsCounter wcCode;
    public GameObject timer;
    public GameObject wordCount;
    public GameObject finalScreen;

    int finalScore;
    int finalMark;
    public Text finalScoreTxt;
    public Text finalMarkTxt;

    void Start()
    {
        txt = GetComponent<Text>();
        wsCode = GameObject.FindGameObjectWithTag("WordGenerator").GetComponent<WordsSpawner>();
        wcCode = GameObject.FindGameObjectWithTag("wordsCounterUI").GetComponent<WordsCounter>();
    }

    void Update()
    {
        if (timeLeft < 0)
        {
            Time.timeScale = 0;
            timeLeft = 0;
            wsCode.enabled = false;
            timer.SetActive(false);
            wordCount.SetActive(false);
            finalScreen.SetActive(true);

            finalScore = wcCode.counter;
            finalScoreTxt.text = finalScore.ToString();

            if (finalScore <= 10 && finalScore >= 9)
                finalMark = 5;
            else if (finalScore <= 8 && finalScore >= 7)
                finalMark = 4;
            else if (finalScore <= 6 && finalScore >= 4)
                finalMark = 3;
            else
                finalMark = 2;
            finalMarkTxt.text = finalMark.ToString();


        }
        timeLeft -= Time.deltaTime;
        txt.text = "Осталось времени: " + Mathf.Round(timeLeft);
    }
}
