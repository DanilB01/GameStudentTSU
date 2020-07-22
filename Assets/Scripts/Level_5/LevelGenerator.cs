using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject enemy;
    public GameObject plusic;


    public int numberOfplatforms;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;

    public float minX = .2f;
    public float maxX = 1f;

    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        Vector3 enemyPos = new Vector3();
        Vector3 plusPos = new Vector3();

        for (int i = 0; i< numberOfplatforms;i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            if (i % 2 == 0)
                spawnPosition.x += Random.Range(minX, maxX);
            else
                spawnPosition.x -= Random.Range(minX, maxX);

            if ( i % 15 == 0 &&  i != 0)
            {
                Instantiate(plusic, spawnPosition, Quaternion.identity);
            }
            else if ((i % 10 == 0 || i % 25 == 0 )&& i != 0)
            {
                enemyPos.x = spawnPosition.x + Mathf.Pow(-1, k) * 0.7f;
                enemyPos.y = spawnPosition.y;
                Instantiate(enemy, enemyPos, Quaternion.identity);
            }
            else
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
