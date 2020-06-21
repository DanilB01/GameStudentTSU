using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloors : MonoBehaviour
{
    int floorNum = 0;
    bool ifTrig = false;
    public GameObject floor0;
    public GameObject floor1;
    public GameObject PressEPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ifTrig)
            {
                if(floorNum == 1)
                {
                    floor1.SetActive(false);
                    floor0.SetActive(true);
                    floorNum = 0;
                }
                else
                {
                    floor0.SetActive(false);
                    floor1.SetActive(true);
                    floorNum = 1;
                }
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
