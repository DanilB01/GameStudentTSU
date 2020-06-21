using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charge : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;
    float interval = 1.5f;

    void Start()
    {

        rb.velocity = new Vector2(Weapon.shootDirection.x * speed, Weapon.shootDirection.y * speed);
        Destroy(gameObject, interval);
    }
  
}
