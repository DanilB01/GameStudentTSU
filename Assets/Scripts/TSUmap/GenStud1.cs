using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenStud1 : MonoBehaviour
{
    public GameObject[] Student;
    public Transform[] GenPoint;
    private float timer;
    private int selector;

    
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(50f, 80f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            if (DestStud.endWay == false)
            {
                selector = Random.Range(0, 2);
                Instantiate(Student[selector], GenPoint[selector]);
                DestStud.endWay = true;
            }
            else
            {
                timer = Random.Range(30f, 50f);
            }
            }
        else
        {
            timer -= Time.deltaTime;
        }
        
    }
}
