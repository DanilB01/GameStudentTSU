using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timeLeftCounter : MonoBehaviour
{

    Text text;
    public static float timeLeft = 180f;
    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
            timeLeft = 0;
        text.text = "Time left: " + Mathf.Round(timeLeft);
    }
}
