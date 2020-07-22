using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenCar1 : MonoBehaviour
{
    public GameObject[] CarsToRight;

    public Transform PointToRight;

    public int carSelect1;

    public float timerToRight;


    // Start is called before the first frame update
    void Start()
    {
        timerToRight = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {

        if (timerToRight < 0)
        {
            carSelect1 = Random.Range(0, 5);
            Instantiate(CarsToRight[carSelect1], PointToRight);
            timerToRight = Random.Range(1, 4);
        }
        else
        {
            timerToRight -= Time.deltaTime;
        }

    }
}
