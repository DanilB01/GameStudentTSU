using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenCar2 : MonoBehaviour
{
    public GameObject[] CarsToLeft;
    
    public Transform PointToLeft;

    public int carSelect2;
    
    public float timerToLeft;
    

    // Start is called before the first frame update
    void Start()
    {        
        timerToLeft = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timerToLeft < 0)
        {
            carSelect2 = Random.Range(0, 5);
            Instantiate(CarsToLeft[carSelect2], PointToLeft);
            timerToLeft = Random.Range(1, 4);
        }
        else
        {
            timerToLeft -= Time.deltaTime;
        }

    }
}
