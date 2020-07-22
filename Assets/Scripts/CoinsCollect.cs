using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollect : MonoBehaviour
{
    private Text coinsCounter;

    void Start()
    {
        coinsCounter = GetComponent<Text>();
    }

    void Update()
    {
        coinsCounter.text = "X" + DataHolder.coinsCount;
    }
}
