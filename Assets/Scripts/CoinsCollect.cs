using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollect : MonoBehaviour
{
    public static int coinsCount;
    private Text coinsCounter;

    // Start is called before the first frame update
    void Start()
    {
        coinsCounter = GetComponent<Text>();
        coinsCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinsCounter.text = "X" + coinsCount;
    }
}
