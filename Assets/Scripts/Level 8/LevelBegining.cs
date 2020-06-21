using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LevelBegining : MonoBehaviour
{
    ServerStatus servScript;
    public GameObject timer;
    public GameObject servCount;
    public GameObject invetory;

    private void Start()
    {
        servScript = GameObject.FindGameObjectWithTag("Servers").GetComponent<ServerStatus>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            servScript.enabled = true;
            timer.SetActive(true);
            servCount.SetActive(true);
            invetory.SetActive(true);
        }
    }
}
