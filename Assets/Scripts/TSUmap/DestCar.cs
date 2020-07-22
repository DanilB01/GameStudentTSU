using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestCar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Destroy(collision.gameObject);
        }
    }
}
