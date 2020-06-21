using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float movSpeed = 1.5f;
    Rigidbody2D rb;
    public float movement = 0f;
    //public int plusCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal"); //* movSpeed;
        //Movement code here
    }
 void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy") || other.CompareTag("attack_ball"))
        {
            if (ScoreScript.scoreVal > 0)
                ScoreScript.scoreVal--;
            soundManager.PlaySound("hit_sound");

        }
        if (other.CompareTag("Plus"))
        {
            ScoreScript.scoreVal++;
            soundManager.PlaySound("collect_sound");
        }
    }
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
}
