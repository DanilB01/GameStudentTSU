using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public int howManyNewWords = 3;
    
    //public float minY = .2f;
    //public float maxY = 3f;
    float posY = 15f;

    float minX = -17f;
    float maxX = 17f;

    float timer = 2;

    void Update()
    {
        if (timer == 2)
        {
            Vector3 spawnPosition = new Vector3();

            for (int i = 0; i < howManyNewWords; i++)
            {
                spawnPosition.y = posY;
                spawnPosition.x = Random.Range(minX, maxX);
                Instantiate(wordPrefab, spawnPosition, Quaternion.identity);
            }
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
            timer = 2;
    }

}
