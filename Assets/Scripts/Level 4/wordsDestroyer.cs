using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordsDestroyer : MonoBehaviour
{
    public bool isCorrectWord;
    WordsCounter wc;
    private void Start()
    {
        wc = GameObject.FindGameObjectWithTag("wordsCounterUI").GetComponent<WordsCounter>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("DeleteBorder"))
        {
            if (collision.CompareTag("Player"))
            {
                if(isCorrectWord)
                    wc.counter++;
                else
                    wc.counter--;
            }
            Destroy(gameObject);
        }
    }
}
