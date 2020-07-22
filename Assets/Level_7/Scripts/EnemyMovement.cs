 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D enemyRigidBody;
    bool face;
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        face = IsFacingRight();
        if (face)
        {
            enemyRigidBody.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(-moveSpeed, 0);

        }
    }
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)), 1f); 
    }
}
