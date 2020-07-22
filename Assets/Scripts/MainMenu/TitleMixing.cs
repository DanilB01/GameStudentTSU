using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMixing : MonoBehaviour
{
    public GameObject[] txt;
    public float tsize;

    float time = 0;
    int c = 2;

    private void Start()
    {
        time = tsize;
    }

    private void Update()
    {
        if (time == tsize)
        {
            SetAllEnabled();
            txt[c].SetActive(true);
            c--;
            if (c == -1)
                c = 2;
        }
        time -= Time.deltaTime;
        if(time < 0)
        {
            time = tsize;
        }
    }

    void SetAllEnabled()
    {
        for(int i = 0; i < txt.Length; i++)
        {
            txt[i].SetActive(false);
        }
    }
}
