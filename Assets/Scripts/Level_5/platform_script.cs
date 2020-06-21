using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_script : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb)
            {
                soundManager.PlaySound("jump_sound");
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}
