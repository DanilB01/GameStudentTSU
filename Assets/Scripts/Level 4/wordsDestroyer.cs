using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordsDestroyer : MonoBehaviour
{
    WordsCounter wc;
    private void Start()
    {
        wc = GameObject.FindGameObjectWithTag("wordsCounterUI").GetComponent<WordsCounter>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("DeleteBorder"))
        {
            Destroy(gameObject);
            if (collision.CompareTag("Player"))
            {
                wc.counter++;
            }
        }
    }
}
