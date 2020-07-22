using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitty_wait : MonoBehaviour
{
    [SerializeField] AudioClip waitSound;
    void Start()
    {
        StartCoroutine("PlayPauseCoroutine");
    }
    IEnumerator PlayPauseCoroutine()
    {
        yield return new WaitForSeconds(5);
        while (!PlatfPlayer.WithKitty)
        {
            AudioSource.PlayClipAtPoint(waitSound, Camera.main.transform.position);
            yield return new WaitForSeconds(7);
        }
    }
}
