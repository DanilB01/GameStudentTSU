using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDest : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            Destroy(collision.gameObject);
        }
    }
}
