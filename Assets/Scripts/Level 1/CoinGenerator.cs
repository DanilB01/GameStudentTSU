using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

    private int num;

    public void SpawnCoins(Vector3 startPosition)
    {
        num = Random.Range(0, 3);
        switch (num) 
        {
            case 0:
                GameObject coin1 = coinPool.GetPooledObject();
                coin1.transform.position = startPosition;
                coin1.SetActive(true);
                break;
            case 1:
                GameObject coin2 = coinPool.GetPooledObject();
                coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
                coin2.SetActive(true);
                break;
            case 2:
                GameObject coin3 = coinPool.GetPooledObject();
                coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
                coin3.SetActive(true);
                break;
        }
    }
}
