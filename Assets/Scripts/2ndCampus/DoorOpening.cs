using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger had happened");
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("ifShouldOpen", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger was exited");
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("ifShouldOpen", false);
        }
    }
}
