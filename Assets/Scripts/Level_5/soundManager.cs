using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{

    public static AudioClip playerHitSound, FireSound, downSound, enemyDeathSound, collectSound, fireSound, jumpSound, reloadSound, winSound;
    static AudioSource AudioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("hit_sound");
        FireSound = Resources.Load<AudioClip>("fire_sound");
        downSound = Resources.Load<AudioClip>("falling_down");
        enemyDeathSound = Resources.Load<AudioClip>("death_sound");
        collectSound = Resources.Load<AudioClip>("collect_sound");
        jumpSound = Resources.Load<AudioClip>("jump_sound");
        reloadSound = Resources.Load<AudioClip>("reload_sound");
        winSound = Resources.Load<AudioClip>("win_sound");

        AudioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "hit_sound":
                AudioSrc.PlayOneShot(playerHitSound);
                break;
            case "fire_sound":
                AudioSrc.PlayOneShot(FireSound);
                break;
            case "falling down":
                AudioSrc.PlayOneShot(downSound);
                break;
            case "death_sound":
                AudioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "collect_sound":
                AudioSrc.PlayOneShot(collectSound);
                break;
            case "jump_sound":
                AudioSrc.PlayOneShot(jumpSound);
                break;
            case "reload_sound":
                AudioSrc.PlayOneShot(reloadSound);
                break;
            case "win_sound":
                AudioSrc.PlayOneShot(winSound);
                break;
        }    
    }
}
