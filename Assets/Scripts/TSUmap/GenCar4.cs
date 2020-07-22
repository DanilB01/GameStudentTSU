using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenCar4 : MonoBehaviour
{ 
    public GameObject[] CarsToLeft;
    
    public Transform PointToLeft;

    public int carSelect4;

    public float timerToMiddleLeft;


    // Start is called before the first frame update
    void Start()
    {
        timerToMiddleLeft = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerToMiddleLeft < 0)
        {
            carSelect4 = Random.Range(0, 5);
            Instantiate(CarsToLeft[carSelect4], PointToLeft);
            timerToMiddleLeft = Random.Range(1, 4);
        }
        else
        {
            timerToMiddleLeft -= Time.deltaTime;
        }

    }
}
