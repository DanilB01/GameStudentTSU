using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsSpawner : MonoBehaviour
{
    public GameObject[] wordsPrefab;
    public Transform[] GenPoint;
    public AudioSource[] soundWords;
    bool[] isUsed = new bool[20] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public int howManyNewWords = 3;
    int whichWord;

    float minX = -17f;
    float maxX = 17f;
    float timer = 3.5f;

    void Update()
    {
        if (timer == 3.5f)
        {
            whichWord = Random.Range(0, 20);
            while(isUsed[whichWord])
                whichWord = Random.Range(0, 20);
            soundWords[whichWord].Play();
            for (int i = 0; i < howManyNewWords; i++)
            {
                GenPoint[i].position = new Vector3(Random.Range(minX, maxX), GenPoint[i].position.y);
                Instantiate(wordsPrefab[whichWord * 3 + i], GenPoint[i]);
            }
            isUsed[whichWord] = true;
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
            timer = 3.5f;
    }

}
