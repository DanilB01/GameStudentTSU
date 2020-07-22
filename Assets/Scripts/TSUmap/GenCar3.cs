using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenCar3 : MonoBehaviour
{
    public GameObject[] CarsToRight;

    public Transform PointToRight;

    public int carSelect3;
   
    public float timerToMiddleRight;


    // Start is called before the first frame update
    void Start()
    {  
        timerToMiddleRight = Random.Range(1, 4); 
    }

    // Update is called once per frame
    void Update()
    {

        if (timerToMiddleRight < 0)
        {
            carSelect3 = Random.Range(0, 5);
            Instantiate(CarsToRight[carSelect3], PointToRight);
            timerToMiddleRight = Random.Range(1, 4);
        }
        else
        {
            timerToMiddleRight -= Time.deltaTime;
        }

    }
}
