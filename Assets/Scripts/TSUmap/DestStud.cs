using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestStud : MonoBehaviour
{
    public static bool endWay = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Student")
        {
            Destroy(collision.gameObject);
            endWay = false;
        }
    }
}
