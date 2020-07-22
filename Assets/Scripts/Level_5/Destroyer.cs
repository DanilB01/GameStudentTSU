using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{

    public GameObject player;
    public GameObject timesUp, restartButton;
    public GameObject timeCounter;
    public static bool isEnd = false;
    public GameObject scoreRightPanel;
    public GameObject winFinalPanel;
    public GameObject loseFinalPanel;
    [SerializeField] AudioSource LevelTheme;

    void Update()
    {
        if (timeLeftCounter.timeLeft <= 0)
        {
            PlayerWin();
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
        //Destroy(player);
        soundManager.PlaySound("win_sound");
        scoreRightPanel.SetActive(false);
        winFinalPanel.SetActive(true);
        //tp player to final platflorm for final conversation with Рыжкова
    }
    public void PlayerDie()
    {
        isEnd = true;
        PlatPlayer.isAlive = false;
        LevelTheme.Stop();
        soundManager.PlaySound("falling down");
        Time.timeScale = 0;
        Destroy(player);
        scoreRightPanel.SetActive(false);
        loseFinalPanel.SetActive(true);
        //timesUp.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        timeCounter.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
