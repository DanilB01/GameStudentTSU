using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCat : MonoBehaviour
{
    private Animator Anim;
    private float timer;

    private bool[] isUsed = new bool[9] { false, false, false, false, false, false, false, false, false };

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
            switch (current)
            {
                case 0:
                    {
                        timer = 7; 
                        isUsed[current] = true;
                        while (isUsed[current])
                        {
                            current = Random.Range(0, 9);
                        }
                        Anim.SetInteger("CurPos", current);
                        break;
                    }
                case 1:
                    {
                        timer = 7;
                        isUsed[current] = true;
                        while (isUsed[current])
                        {
                            current = Random.Range(0, 9);
                        }
                        Anim.SetInteger("CurPos", current);
                        break;
                    }
                case 2:
                    {
                        timer = 7;
                        isUsed[current] = true;
                        while (isUsed[current])
                        {
                            current = Random.Range(0, 9);
                        }
                        Anim.SetInteger("CurPos", current);
                        break;
                    }
                case 3:
                    {
                        timer = 7;
                        isUsed[current] = true;
                        while (isUsed[current])
                        {
                            current = Random.Range(0, 9);
                        }
                        Anim.SetInteger("CurPos", current);
                        break;
                    }
                case 4:
                    {
                        timer = 7;
                        isUsed[current] = true;
                        while (isUsed[current])
                        {
                            current = Random.Range(0, 9);
                        }
                        Anim.SetInteger("CurPos", current);
                        break;
                    }
                case 5:
                    {
                        timer = 7;
                        isUsed[current] = true;
                        while (isUsed[current])
                        {
                            current = Random.Range(0, 9);
                        }
                        Anim.SetInteger("CurPos", current);
                        break;
                    }
                case 6:
                    {
                        timer = 7;
                        isUsed[current] = true;
                        while (isUsed[current])
                        {
                            current = Random.Range(0, 9);
                        }
                        Anim.SetInteger("CurPos", current);
                        break;
                    }
                case 7:
                    {
                        timer = 7;
                        isUsed[current] = true;
                        while (isUsed[current])
                        {
                            current = Random.Range(0, 9);
                        }
                        Anim.SetInteger("CurPos", current);
                        break;
                    }
                case 8:
                    {
                        timer = 7;
                        isUsed[current] = true;
                        isUsed[1] = true;
                        isUsed[2] = true;
                        isUsed[3] = true;
                        isUsed[4] = true;
                        while (isUsed[current])
                        {
                            current = Random.Range(0, 9);
                        }
                        Anim.SetInteger("CurPos", current);
                        break;
                    }
            }
            for (int i = 0; i < 9; i++)
            {
                isUsed[i] = false;
            }
        }

        switch (current)
        {
            case 0:
                {
                    direction = Vector2.zero;
                    break;
                }
            case 1:
                {
                    direction = Vector2.zero;
                    direction += Vector2.up;
                    transform.Translate(direction * speed * Time.deltaTime);
                    break;
                }
            case 2:
                {
                    direction = Vector2.zero;
                    direction += Vector2.right;
                    transform.Translate(direction * speed * Time.deltaTime);
                    break;
                }
            case 3:
                {
                    direction = Vector2.zero;
                    direction += Vector2.down;
                    transform.Translate(direction * speed * Time.deltaTime);
                    break;
                }
            case 4:
                {
                    direction = Vector2.zero;
                    direction += Vector2.left;
                    transform.Translate(direction * speed * Time.deltaTime);
                    break;
                }
            case 5:
                {
                    direction = Vector2.zero;
                    break;
                }
            case 6:
                {
                    direction = Vector2.zero;
                    break;
                }
            case 7:
                {
                    direction = Vector2.zero;
                    break;
                }
            case 8:
                {
                    direction = Vector2.zero;
                    break;
                }
        }
        timer -= Time.deltaTime;
    }
}
