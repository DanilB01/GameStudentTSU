using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitL3ToTsuMap : MonoBehaviour
{
    [SerializeField] AudioClip holeExitSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(holeExitSFX, Camera.main.transform.position);
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        SceneManager.LoadScene("TSUmap");
    }
}
