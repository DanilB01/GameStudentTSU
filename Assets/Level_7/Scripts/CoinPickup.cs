using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    Text coinss;

    private void Start()
    {
        coinss = GameObject.FindGameObjectWithTag("timerFor7lvl").GetComponent<Text>();
        coinss.text = "X" + PlatfPlayer.coinsCounter.ToString();
    }

    bool destroyed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            destroyed = true;
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            PlatfPlayer.coinsCounter++;
            coinss.text = "X" + PlatfPlayer.coinsCounter.ToString();
            Destroy(gameObject);
        }
    }
}
