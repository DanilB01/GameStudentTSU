using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorScript : MonoBehaviour
{ 
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "platform")
            Destroy(coll.gameObject);

        //if (coll.gameObject.name == "Player")
            //Destroyer.PlayerDie();
    }
}
