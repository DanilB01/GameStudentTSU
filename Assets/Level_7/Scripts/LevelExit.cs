using System.Collections;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1.5f;
    [SerializeField] AudioClip holeEnterSFX;
    [SerializeField] AudioClip holeExitSFX;

    public bool IsEnter = true;
    public bool IsFinal = false;
    private bool isPlayedAtOnce = false;
    //public Transform SpawnPoint;

    void Update()
    {
        if (PlatfPlayer.WithKitty && !IsEnter)
            isPlayedAtOnce = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPlayedAtOnce)
        {
            if (IsFinal && PlatfPlayer.WithKitty)
            {
                AudioSource.PlayClipAtPoint(holeEnterSFX, Camera.main.transform.position);
                StartCoroutine(LoadNextLevel());
            }
            if (IsEnter && !PlatfPlayer.WithKitty)
            {
                AudioSource.PlayClipAtPoint(holeEnterSFX, Camera.main.transform.position);
                other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(LoadNextLevel());
            }
            else if (IsEnter && PlatfPlayer.WithKitty)
            {
                AudioSource.PlayClipAtPoint(holeExitSFX, Camera.main.transform.position);
            }
            else if (PlatfPlayer.WithKitty == false)
            {
                AudioSource.PlayClipAtPoint(holeExitSFX, Camera.main.transform.position);
            }
            else
            {
                AudioSource.PlayClipAtPoint(holeEnterSFX, Camera.main.transform.position);
                other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(LoadNextLevel(true));
            }
        }
        isPlayedAtOnce = true;
    }
    IEnumerator LoadNextLevel(bool goBack = false)
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        if (IsFinal)
        {
            SceneManager.LoadScene("Success");
        }
        else if (goBack)
            SceneManager.LoadScene("zero");
        else SceneManager.LoadScene("first");
    }
   
    /*IEnumerator LoadNextLevel(bool goBack = false)
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        if (IsFinal)
        {
            SceneManager.LoadScene(6);
        }
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (goBack)
            currentSceneIndex -= 1;
        //Scene index starts from 0
        else currentSceneIndex += 1;
        SceneManager.LoadScene(currentSceneIndex);
    }*/
}
