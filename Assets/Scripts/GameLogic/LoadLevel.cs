using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]public static bool ReadyToGo = false;

    void Start()
    {
        ReadyToGo = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ReadyToGo)
        {
            if (collision.name == "Level1")
            {
                SceneManager.LoadScene("Level 1");
            }
            if (collision.name == "Level7")
            {
                SceneManager.LoadScene("zero");
            }
            if (collision.name == "Level5")
            {
                SceneManager.LoadScene("Level 5");
            }
            if (collision.name == "Level3")
            {
                SceneManager.LoadScene("BasementMain");
            }
            if (collision.name == "Level8")
            {
                SceneManager.LoadScene("Level 8");
            }
            if (collision.name == "Level6")
            {
                SceneManager.LoadScene("Level 6");
            }
        }
    }
}
