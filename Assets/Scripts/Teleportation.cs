using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public int location;
    public GameObject PressEPanel;
    bool ifTrig = false;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ifTrig)
            {
                SceneManager.LoadScene(location);
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
