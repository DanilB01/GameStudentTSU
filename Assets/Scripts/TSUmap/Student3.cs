using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student3 : MonoBehaviour
{
    private Animator Anim;
    private float timer;

    private Vector2 direction;
    public float speed;

    private int current;
    private bool itWas = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        timer = 7;
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            if(current == -1)
            {
                timer = 7;
                current = 0;
                itWas = false;
                Anim.SetInteger("CurPos", current);
            }

            else if (current == 0)
            {
                //Anim.SetInteger("CurPos", 0);

                timer = 7;

                if(itWas == false)
                {
                    current = 1;

                }
                else
                {
                    current = -1;
                }
                Anim.SetInteger("CurPos", current);
            }

            else if (current == 1)
            {
                //Anim.SetInteger("CurPos", -1);

                timer = 7;
                itWas = true;
                current = 0;
                Anim.SetInteger("CurPos", current);
            }

        }
        if (current == -1)
        {
            direction = Vector2.zero;
            direction += Vector2.up;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else if(current == 0)
        {
            direction = Vector2.zero;
        }
        else if(current == 1)
        {
            direction = Vector2.zero;
            direction += Vector2.down;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        timer -= Time.deltaTime;
    }
}
