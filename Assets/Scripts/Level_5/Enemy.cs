using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float Speed;
    public float minRangeDistance = 5f;

    public float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public GameObject plus;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Charge"))
        {
            Instantiate(plus, transform.position, Quaternion.identity);
            soundManager.PlaySound("death_sound");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
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
        if (Vector2.Distance(player.position, transform.position) <= minRangeDistance)
        {
            Shoot();
        }
    }
}
