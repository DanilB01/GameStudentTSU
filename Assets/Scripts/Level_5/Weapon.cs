using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject charge;
    public float minDistance = 10f;
    public static Vector3 shootDirection;
    private int shootCount = 0;
    bool wait = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (wait)
                StartCoroutine(WaitCoroutine());
            if (shootCount != 3)
            {
                shootCount++;
                soundManager.PlaySound("fire_sound");
                Shoot();
                wait = false;
            }
            else
            {
                wait = true;
                soundManager.PlaySound("reload_sound");
                shootCount = 0;
            }
            }
    }
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(10);
    }
    void Shoot()
    {
        shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        Instantiate(charge, FirePoint.position, Quaternion.identity);
    }
}
