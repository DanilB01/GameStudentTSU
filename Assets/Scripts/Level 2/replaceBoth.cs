using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replaceBoth : MonoBehaviour
{
    public GameObject oppositePoint;
    public moveObjLama lama;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = oppositePoint.transform.position;
        lama.freezeTimer = Random.Range(5f, 10f);
    }
}
