using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreUI : MonoBehaviour
{
    public static bool isDead = false;
    public GameObject finalPanel;

    private void Start()
    {
        isDead = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            finalPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
