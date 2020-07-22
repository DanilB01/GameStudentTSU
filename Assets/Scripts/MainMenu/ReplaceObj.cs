using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObj : MonoBehaviour
{
    //public GameObject obj;
    public GameObject rightPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = rightPoint.transform.position;
    }
}
