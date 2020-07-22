using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObjLama : MonoBehaviour
{
    private Vector2 direction;
    public float speed;
    public int whichLama;
    public float freezeTimer;

    private void Start()
    {
        freezeTimer = Random.Range(5f, 10f);
    }

    private void Update()
    {
        if (freezeTimer < 0)
        {
            direction = Vector2.zero;
            if(whichLama == 1)
                direction -= Vector2.left;
            else
                direction += Vector2.left;
            transform.Translate(direction * speed * Time.deltaTime);
            /*if(transform.position.x < -1000)
            {
                freezeTimer = Random.Range(5f, 10f);
            }*/
        }
        else
            freezeTimer -= Time.deltaTime;
    }
}
