using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public GameObject player;
    public GameObject timesUp, restartButton;
    public GameObject timeCounter;
    public static bool isEnd = false;

    void Update()
    {
        if (timeLeftCounter.timeLeft <= 0)
        {
            if (ScoreScript.scoreVal > 7)
                PlayerWin();
            else
                PlayerDie();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDie();
        }
    }

    public void PlayerWin()
    {
        isEnd = true;
        Destroy(player);
        soundManager.PlaySound("win_sound");
        //tp player to final platflorm for final conversation with Рыжкова
    }
    public void PlayerDie()
    {
        isEnd = true;
        soundManager.PlaySound("falling down");
        Time.timeScale = 0;
        Destroy(player);
        timesUp.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        timeCounter.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
