using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloors : MonoBehaviour
{
    public int floorNum = 1;
    bool ifTrig = false;
    [SerializeField] GameObject floor0;
    [SerializeField] GameObject floor1;
    public GameObject PressEPanel;

    void Start()
    {
        if (Translator.fromLevel == 7)
        {
            floorNum = Translator.floorNum; // if we returned after level 8
        }
    }
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
