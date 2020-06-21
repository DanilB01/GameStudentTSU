using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    Text txt;
    public float timeLeft;
    ServerStatus servstat;
    public GameObject timer;
    public GameObject servCount;
    public GameObject invetory;
    public GameObject finalScreen;

    int finalScore;
    int finalMark;
    public Text finalScoreTxt;
    public Text finalMarkTxt;
    void Start()
    {
        txt = GetComponent<Text>();
        servstat = GameObject.FindGameObjectWithTag("Servers").GetComponent<ServerStatus>();
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Time.timeScale = 0;

            timeLeft = 0;
            servstat.enabled = false;
            timer.SetActive(false);
            servCount.SetActive(false);
            invetory.SetActive(false);
            finalScreen.SetActive(true);

            finalScore = servstat.AliveServers();
            finalScoreTxt.text = finalScore.ToString() + "/12";

            if(finalScore <= 12 && finalScore >= 11)
            {
                finalMark = 5;
            }
            else if(finalScore <= 10 && finalScore >= 8)
            {
                finalMark = 4;
            }
            else if(finalScore <= 7 && finalScore >= 4)
            {
                finalMark = 3;
            }
            else
            {
                finalMark = 2;
            }

            finalMarkTxt.text = finalMark.ToString();
        }
        txt.text = "Осталось времени: " + Mathf.Round(timeLeft);
    }
}
