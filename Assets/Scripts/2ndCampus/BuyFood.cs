using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyFood : MonoBehaviour
{
    public GameObject PressEPanel;
    public GameObject PriceList;
    public GameObject PM;

    PauseMenu pause;

    bool ifTrig = false;
    bool isOpened = false;

    private void Start()
    {
        pause = PM.GetComponent<PauseMenu>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ifTrig)
            {
                if (!isOpened)
                {
                    Time.timeScale = 0;
                    isOpened = true;
                    PriceList.SetActive(true);
                    pause.enabled = false;
                }
                else
                {
                    isOpened = false;
                    PriceList.SetActive(false);
                    pause.enabled = true;
                    Time.timeScale = 1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpened)
            {
                isOpened = false;
                PriceList.SetActive(false);
                pause.enabled = true;
                Time.timeScale = 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            ifTrig = true;
            PressEPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            ifTrig = false;
            PressEPanel.SetActive(false);
        }
    }
}
