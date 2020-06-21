using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsCounter : MonoBehaviour
{
    Text txt;
    public int counter = 0;
    void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        txt.text = "Правильных слов: " + counter;
    }
}
