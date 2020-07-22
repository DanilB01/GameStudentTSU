using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    public float Speed;
    public float minRangeDistance = 5f;

    public float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public GameObject plusAfterEnemy;

    void Start()
    {
        if (PlatPlayer.isAlive)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Charge"))
        {
            Instantiate(plusAfterEnemy, transform.position, Quaternion.identity);
            soundManager.PlaySound("death_sound");
            Destroy(gameObject);
        }
    }

    void Shoot()
    { 
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    void Update()
    {
        if (PlatPlayer.isAlive)
        {
            if (Vector2.Distance(player.position, transform.position) <= minRangeDistance)
            {
                Shoot();
            }
        }
    }
}
