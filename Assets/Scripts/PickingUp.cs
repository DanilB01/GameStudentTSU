using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    [SerializeField] AudioClip takeSound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            AudioSource.PlayClipAtPoint(takeSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
