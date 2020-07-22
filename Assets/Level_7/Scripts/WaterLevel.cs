using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    [Tooltip ("GameObject units per second")]
    [SerializeField] float scrollRate = 0.1f;
    [SerializeField] AudioClip WaterSFX;
    public bool isUp = true;
    public bool isWithKitty = false;
    private bool IsPlayedOnce = false;
    AudioSource m_MyAudioSource;
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Update() 
    {
        isWithKitty = PlatfPlayer.WithKitty;
        if (isWithKitty)
        {
            if (!IsPlayedOnce)
            {
                m_MyAudioSource.PlayOneShot(WaterSFX);
                //AudioSource.PlayClipAtPoint(WaterSFX, Camera.main.transform.position);
                IsPlayedOnce = true;
            }
            if (isUp)
            {
                float yMove = scrollRate * Time.deltaTime;
                transform.Translate(new Vector2(0f, yMove));
            }
            else
            {
                float xMove = -scrollRate * Time.deltaTime;
                transform.Translate(new Vector2(xMove, 0f));
            }

            if (m_MyAudioSource.isPlaying == false)
                IsPlayedOnce = true;
        }
    }
}
