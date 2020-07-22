using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        TakeInput();
        MoveCharacter();
        foreach(int a in Marks.examMarks)
            Debug.Log("exam marks:" + a);
        foreach (int a in Marks.passMarks)
            Debug.Log("pass marks:" + a);

    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            
        }
    }

    private void MoveCharacter()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(direction.x != 0 || direction.y != 0)
        {

            SetAnimatorMovement(direction);
        }

        else
        {
            direction = Vector2.zero;
            animator.SetLayerWeight(1, 0);
        }
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Coins"))
        {
            DataHolder.coinsCount += 1;
        }
    }
}
