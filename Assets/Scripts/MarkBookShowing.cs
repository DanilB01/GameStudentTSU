using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkBookShowing : MonoBehaviour
{
    public GameObject MarkPanel;
    bool IsPressed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!IsPressed)
            {
                MarkPanel.SetActive(true);
                IsPressed = true;
            }
            else
            {
                MarkPanel.SetActive(false);
                IsPressed = false;
            }

        }
    }
}
