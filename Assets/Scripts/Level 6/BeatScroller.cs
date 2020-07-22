using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public static float beat;

    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    void Update()
    {
        beatTempo = beat;
        transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
    }
}
