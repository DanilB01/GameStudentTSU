using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public GameObject PressEPanel;
    bool ifTrig = false;
    string toLocation = "SecondCampus";
    [SerializeField] bool isCutScene = false;
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isCutScene && SceneManager.GetActiveScene().name == "PC_Screen")
            {
                SceneManager.LoadScene("MainMenu");
                Translator.fromLevel = 8;
            }
        
            if (ifTrig)
            {
                Translator.fromLevel = 9;
                if (SceneManager.GetActiveScene().name == "SecondCampus")
                    toLocation = "TSUmap";
                if (SceneManager.GetActiveScene().name == "Opening Cutscene")
                    toLocation = "PC_Screen";

                SceneManager.LoadScene(toLocation);
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
