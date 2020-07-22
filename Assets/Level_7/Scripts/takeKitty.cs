using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeKitty : MonoBehaviour
{
    [SerializeField] AudioClip WaterStartRisingSFX;
    public Sprite box_without_kitty;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject kitty = GameObject.FindGameObjectWithTag("kitty_in_box");
            Destroy(kitty);
            PlatfPlayer.WithKitty = true;
            AudioSource.PlayClipAtPoint(WaterStartRisingSFX, Camera.main.transform.position);
        }
    }
}
