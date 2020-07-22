using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;
    private bool isDestoyed = false;

    public float interval = 1.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

        Destroy(gameObject, interval);
    }

    // Update is called once per frame

    void DestroyProjectile()
    {
        isDestoyed = true;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Charge"))
        {
            DestroyProjectile();
        }
    }
    void Update()
    {
        if (!isDestoyed && PlatPlayer.isAlive)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (transform.position.x == player.position.x && transform.position.y == player.position.y)
            DestroyProjectile();

    }
}
