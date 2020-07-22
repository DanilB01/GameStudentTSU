using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePlusic : MonoBehaviour
{
    [SerializeField] AudioClip plusSound;
    [SerializeField] AudioClip plusDestroyerSound;
    [SerializeField] bool afterEnemy = false;
    [SerializeField] float timeBeforeDestroy = 3f;

    void makePlusChanges(AudioClip sound)
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            makePlusChanges(plusSound);
        }
    }

    void Update()
    {
        if (afterEnemy)
        {
            timeBeforeDestroy -= Time.deltaTime;
            if (timeBeforeDestroy <= 0)
            {
                makePlusChanges(plusDestroyerSound);
            }
        }
    }
}
