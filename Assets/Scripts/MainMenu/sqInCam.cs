using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sqInCam : MonoBehaviour
{
    private Vector2 direction;
    public float speed;

    bool ifRightDownPos = true;
    public float freezeTimer;

    private void Start()
    {
        freezeTimer = Random.Range(3f, 6f);
    }
    void Update()
    {
        if (freezeTimer < 0)
        {
            direction = Vector2.zero;
            if (ifRightDownPos)
            {
                direction += Vector2.left;
                direction += Vector2.up;
            }
            else
            {
                direction += Vector2.right;
                direction += Vector2.down;
            }
            transform.Translate(direction * speed * Time.deltaTime);
            if(transform.position.x < 8 && transform.position.y > -2)
            {
                ifRightDownPos = false;
            }
            else if (transform.position.x > 11 && transform.position.y < -6)
            {
                ifRightDownPos = true;
                freezeTimer = Random.Range(3, 7);
            }
        }
        else
            freezeTimer -= Time.deltaTime;
        
    }
}
